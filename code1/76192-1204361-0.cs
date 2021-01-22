        public static List<IExample> GetExamples()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i == typeof(IExample))).ToList();
            
            List<IExample> returnMe = new List<IExample>();
            foreach (var type in types)
                returnMe.Add((IExample) Activator.CreateInstance(type));
            return returnMe;
        }
