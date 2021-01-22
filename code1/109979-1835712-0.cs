    public List<Type> GetList()
            {
                List<Type> types = new List<Type>();
                var assembly = Assembly.GetExecutingAssembly();
                foreach (var type in assembly .GetTypes())
                {
                    if (type.Namespace == "Namespace")
                    {
                        types.Add(type);
                    }
                }
                return types;
            }
