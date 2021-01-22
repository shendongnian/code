        static void Main(string[] args)
        {
            XmlDocument foo = new XmlDocument();
            foreach (System.Reflection.Assembly item in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine(item.FullName);
            }
        }
