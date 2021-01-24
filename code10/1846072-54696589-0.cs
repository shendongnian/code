    using System;
    using System.Collections.Generic;
    using System.Reflection;
    class Program
    {
        static void Main(string[] args)
        {
            LoadAssemAndShowPublicTypes("Assembly Name Here");
        }
        private static void LoadAssemAndShowPublicTypes(String assemId)
        {
            Assembly a = Assembly.Load(assemId);
            List<Type> currentAssemblyTypes = new List<Type>();
            int i = 0;
            foreach (Type t in a.ExportedTypes)
            {
                currentAssemblyTypes.Add(t);
                Console.WriteLine($"{++i} - {t.FullName}");
            }
            Console.WriteLine("Which one(s) would you like to Invoke?");
            String userChoice = Console.ReadLine();
            if (userChoice != "0")
            {
                CreateInstance(currentAssemblyTypes[Convert.ToInt32(userChoice) - 1]);
            }
        }
        private static void CreateInstance(Type requestedType)
        {
            Object obj = Activator.CreateInstance(requestedType);
        }
    }
