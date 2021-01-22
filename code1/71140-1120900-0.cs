        private static void ListFields(Type type)
        {
            Console.WriteLine(type.Name);
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(string.Format("{0} of type {1}", field.Name, field.FieldType.Name));
                if (field.FieldType.IsClass)
                {
                    ListFields(field.FieldType);
                }
            }
        }
