     var properties= typeof(Sample).GetProperties();
            var myAssembly = Assembly.GetCallingAssembly().FullName;
            foreach(var prop in properties)
            {
                if (Assembly.GetAssembly(prop.PropertyType).FullName.Equals(myAssembly))
                    Console.WriteLine(prop.Name);// this belongs to your assembly
            }
