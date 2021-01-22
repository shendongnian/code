    public class Class
        {
            public static List<Class> FromFiles(IEnumerable<String> paths)
            {
                List<Class> instances = new List<Class>();
                foreach (string path in paths)
                {
                    instances.Add(new Class() { Path = path });
                }
                return instances;
            }
            public string Path { get; set; }
        }
