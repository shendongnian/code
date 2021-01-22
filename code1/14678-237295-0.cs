        static void ListArrayListMembers(ArrayList list)
        {
            foreach (object obj in list)
            {
                Type type = obj.GetType();
                foreach (FieldInfo field in type.GetFields(BindingFlags.Public))
                {
                    Console.WriteLine(field.Name + " = " + field.GetValue(obj).ToString());
                }
            }
        }
