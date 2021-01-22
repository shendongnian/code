    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using LumenWorks.Framework.IO.Csv;
    class Entity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }
    
    }
    static class Program {
    
        static void Main()
        {
            string path = "data.csv";
            InventData(path);
    
            int count = 0;
            foreach (Entity obj in Read<Entity>(path))
            {
                count++;
            }
            Console.WriteLine(count);
        }
        static IEnumerable<T> Read<T>(string path)
            where T : class, new()
        {
            using (TextReader source = File.OpenText(path))
            using (CsvReader reader = new CsvReader(source,true,delimiter)) {
    
                string[] headers = reader.GetFieldHeaders();
                Type type = typeof(T);
                List<MemberBinding> bindings = new List<MemberBinding>();
                ParameterExpression param = Expression.Parameter(typeof(CsvReader), "row");
                MethodInfo method = typeof(CsvReader).GetProperty("Item",new [] {typeof(int)}).GetGetMethod();
                Expression invariantCulture = Expression.Constant(
                    CultureInfo.InvariantCulture, typeof(IFormatProvider));
                for(int i = 0 ; i < headers.Length ; i++) {
                    MemberInfo member = type.GetMember(headers[i]).Single();
                    Type finalType;
                    switch (member.MemberType)
                    {
                        case MemberTypes.Field: finalType = ((FieldInfo)member).FieldType; break;
                        case MemberTypes.Property: finalType = ((PropertyInfo)member).PropertyType; break;
                        default: throw new NotSupportedException();
                    }
                    Expression val = Expression.Call(
                        param, method, Expression.Constant(i, typeof(int)));
                    if (finalType != typeof(string))
                    {
                        val = Expression.Call(
                            finalType, "Parse", null, val, invariantCulture);
                    }
                    bindings.Add(Expression.Bind(member, val));
                }
                
                Expression body = Expression.MemberInit(
                    Expression.New(type), bindings);
    
                Func<CsvReader, T> func = Expression.Lambda<Func<CsvReader, T>>(body, param).Compile();
                while (reader.ReadNextRecord()) {
                    yield return func(reader);
                }
            }
        }
        const char delimiter = '\t';
        static void InventData(string path)
        {
            Random rand = new Random(123456);
            using (TextWriter dest = File.CreateText(path))
            {
                dest.WriteLine("Id" + delimiter + "DateOfBirth" + delimiter + "Name");
                for (int i = 0; i < 10000; i++)
                {
                    dest.Write(rand.Next(5000000));
                    dest.Write(delimiter);
                    dest.Write(new DateTime(
                        rand.Next(1960, 2010),
                        rand.Next(1, 13),
                        rand.Next(1, 28)).ToString(CultureInfo.InvariantCulture));
                    dest.Write(delimiter);
                    dest.Write("Fred");
                    dest.WriteLine();
                }
                dest.Close();
            }
        }
    }
