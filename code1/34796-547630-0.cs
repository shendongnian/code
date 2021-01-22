    class Class1
    {
        public static void Run()
        {
            doTopologicalTest();
        }
        private static void doTopologicalTest()
        {
            List<Field> fields = new List<Field>();
            fields.Add(new Field() { Name = "FirstName" });
            fields.Add(new Field()
            {
                Name = "FullName",
                DependsOn = new[] { "FirstName", "LastName" }
            });
            fields.Add(new Field()
            {
                Name = "Age",
                DependsOn = new[] { "DateOfBirth" }
            });
            fields.Add(new Field() { Name = "LastName" });
            fields.Add(new Field() { Name = "DateOfBirth" });
            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
                if(field.DependsOn != null)
                    foreach (var item in field.DependsOn)
                    {
                        Console.WriteLine(" -{0}",item);
                    }
            }
            Console.WriteLine("\n...Sorting...\n");
            int[] sortOrder = getTopologicalSortOrder(fields);
            for (int i = 0; i < sortOrder.Length; i++)
            {
                var field = fields[sortOrder[i]];
                Console.WriteLine(field.Name);
                if (field.DependsOn != null)
                    foreach (var item in field.DependsOn)
                    {
                        Console.WriteLine(" -{0}", item);
                    }
            }
        }
        private static int[] getTopologicalSortOrder(List<Field> fields)
        {
            TopologicalSorter g = new TopologicalSorter();
            Dictionary<string, int> _indexes = new Dictionary<string, int>(); 
           
            //add vertices
            for (int i = 0; i < fields.Count;i++)
            {
                g.AddVertex((char)i);
                _indexes[fields[i].Name.ToLower()] = i;
            }
            
            //add edges
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].DependsOn != null)
                {
                    for (int j = 0; j < fields[i].DependsOn.Length; j++)
                    {
                        g.AddEdge(i, 
                            _indexes[fields[i].DependsOn[j].ToLower()]);
                    }
                }                
            }
            char[] array = g.Sort();
            int[] result = new int[fields.Count];
            for (int i = 0; i < fields.Count; i++)
            {
                result[i] = (int)array[i];
            }
            return result;
            
        }
        
        class Field
        {
            public string Name { get; set; }
            public string[] DependsOn { get; set; }
        }
    }
