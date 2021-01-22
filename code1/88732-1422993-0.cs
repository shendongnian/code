            var tableType = db.MyTable.GetType().GetGenericArguments().First();
            foreach (TableAttribute attrib in tableType.GetCustomAttributes(false))
            {
                Console.WriteLine(attrib.Name);
            }
