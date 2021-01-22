    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    public static class Programm
    {
        public const string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestDb2;Persist Security Info=True;integrated Security=True";
        static void Main()
        {
            using (var dc = new DataContextDom(ConnectionString))
            {
                if (dc.DatabaseExists())
                    dc.DeleteDatabase();
                dc.CreateDatabase();
                dc.GetTable<DataHelperDb1>().InsertOnSubmit(new DataHelperDb1() { Name = "DataHelperDb1Desc1", Id = 1 });
                dc.GetTable<DataHelperDb2>().InsertOnSubmit(new DataHelperDb2() { Name = "DataHelperDb2Desc1", Key1 = "A", Key2 = "1" });
                dc.SubmitChanges();
                Console.WriteLine("Name:" + GetByID(dc.GetTable<DataHelperDb1>(), 1).Name);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Name:" + GetByID(dc.GetTable<DataHelperDb2>(), new PkClass { Key1 = "A", Key2 = "1" }).Name);
            }
        }
        //Datacontext definition
        [Database(Name = "TestDb2")]
        public class DataContextDom : DataContext
        {
            public DataContextDom(string connStr) : base(connStr) { }
            public Table<DataHelperDb1> DataHelperDb1;
            public Table<DataHelperDb2> DataHelperD2;
        }
        [Table(Name = "DataHelperDb1")]
        public class DataHelperDb1 : Entity<DataHelperDb1, int>
        {
            [Column(IsPrimaryKey = true)]
            public int Id { get; set; }
            [Column]
            public string Name { get; set; }
        }
        public class PkClass
        {
            public string Key1 { get; set; }
            public string Key2 { get; set; }
        }
        [Table(Name = "DataHelperDb2")]
        public class DataHelperDb2 : Entity<DataHelperDb2, PkClass>
        {
            [Column(IsPrimaryKey = true)]
            public string Key1 { get; set; }
            [Column(IsPrimaryKey = true)]
            public string Key2 { get; set; }
            [Column]
            public string Name { get; set; }
        }
        public class Entity<TEntity, TKey> where TEntity : new()
        {
            public static TEntity SearchObjInstance(TKey key)
            {
                var res = new TEntity();
                var targhetPropertyInfos = GetPrimaryKey<TEntity>().ToList();
                if (targhetPropertyInfos.Count == 1)
                {
                    targhetPropertyInfos.First().SetValue(res, key, null);
                }
                else if (targhetPropertyInfos.Count > 1) 
                {
                    var sourcePropertyInfos = key.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var sourcePi in sourcePropertyInfos)
                    {
                        var destinationPi = targhetPropertyInfos.FirstOrDefault(x => x.Name == sourcePi.Name);
                        if (destinationPi == null || sourcePi.PropertyType != destinationPi.PropertyType)
                            continue;
                        object value = sourcePi.GetValue(key, null);
                        destinationPi.SetValue(res, value, null);
                    }
                }
                return res;
            }
        }
        public static IEnumerable<PropertyInfo> GetPrimaryKey<T>()
        {
            foreach (var info in typeof(T).GetProperties().ToList())
            {
                if (info.GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(ColumnAttribute))
                .Where(x => ((ColumnAttribute)x).IsPrimaryKey)
                .Any())
                    yield return info;
            }
        }
        //Move in repository pattern
        public static TEntity GetByID<TEntity, TKey>(Table<TEntity> source, TKey id) where TEntity : Entity<TEntity, TKey>, new()
        {
            var searchObj = Entity<TEntity, TKey>.SearchObjInstance(id);
            Console.WriteLine(source.Where(e => e.Equals(searchObj)).ToString());
            return source.Single(e => e.Equals(searchObj));
        }
    }
