    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    
    namespace TableGenerator
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<TableClass> tables = new List<TableClass>();
                
                // Pass assembly name via argument
                Assembly a = Assembly.LoadFile(args[0]);
                                     
                Type[] types = a.GetTypes();
    
                // Get Types in the assembly.
                foreach (Type t in types)
                {
                    TableClass tc = new TableClass(t);                
                    tables.Add(tc);
                }
    
                // Create SQL for each table
                foreach (TableClass table in tables)
                {
                    Console.WriteLine(table.CreateTableScript());
                    Console.WriteLine();
                }
    
                // Total Hacked way to find FK relationships! Too lazy to fix right now
                foreach (TableClass table in tables)
                {
                    foreach (KeyValuePair<String, Type> field in table.Fields)
                    {
                        foreach (TableClass t2 in tables)
                        {
                            if (field.Value.Name == t2.ClassName)
                            {
                                // We have a FK Relationship!
                                Console.WriteLine("GO");
                                Console.WriteLine("ALTER TABLE " + table.ClassName + " WITH NOCHECK");
                                Console.WriteLine("ADD CONSTRAINT FK_" + field.Key + " FOREIGN KEY (" + field.Key + ") REFERENCES " + t2.ClassName + "(ID)");
                                Console.WriteLine("GO");
                                
                            }
                        }
                    }
                }
            }
        }
    
        public class TableClass
        {
            private List<KeyValuePair<String, Type>> _fieldInfo = new List<KeyValuePair<String, Type>>();
            private string _className = String.Empty;
    
            private Dictionary<Type, String> dataMapper
            {
                get
                {
                    // Add the rest of your CLR Types to SQL Types mapping here
                    Dictionary<Type, String> dataMapper = new Dictionary<Type, string>();
                    dataMapper.Add(typeof(int), "BIGINT");
                    dataMapper.Add(typeof(string), "NVARCHAR(500)");
                    dataMapper.Add(typeof(bool), "BIT");
                    dataMapper.Add(typeof(DateTime), "DATETIME");
                    dataMapper.Add(typeof(float), "FLOAT");
                    dataMapper.Add(typeof(decimal), "DECIMAL(18,0)");
                    dataMapper.Add(typeof(Guid), "UNIQUEIDENTIFIER");
    
                    return dataMapper;
                }
            }
    
            public List<KeyValuePair<String, Type>> Fields
            {
                get { return this._fieldInfo; }
                set { this._fieldInfo = value; }
            }
    
            public string ClassName
            {
                get { return this._className; }
                set { this._className = value; }
            }
    
            public TableClass(Type t)
            {
                this._className = t.Name;
    
                foreach (PropertyInfo p in t.GetProperties())
                {
                    KeyValuePair<String, Type> field = new KeyValuePair<String, Type>(p.Name, p.PropertyType);
    
                    this.Fields.Add(field);
                }
            }
    
            public string CreateTableScript()
            {
                System.Text.StringBuilder script = new StringBuilder();
    
                script.AppendLine("CREATE TABLE " + this.ClassName);
                script.AppendLine("(");
                script.AppendLine("\t ID BIGINT,");
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    KeyValuePair<String, Type> field = this.Fields[i];
    
                    if (dataMapper.ContainsKey(field.Value))
                    {
                        script.Append("\t " + field.Key + " " + dataMapper[field.Value]);
                    }
                    else
                    {
                        // Complex Type? 
                        script.Append("\t " + field.Key + " BIGINT");
                    }
    
                    if (i != this.Fields.Count - 1)
                    {
                        script.Append(",");
                    }
    
                    script.Append(Environment.NewLine);
                }
    
                script.AppendLine(")");
    
                return script.ToString();
            }
        }
    }
