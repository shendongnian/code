        public List<T> LoadPlugin<T>(string directory)
        {
            Type interfaceType = typeof(T);
            List<T> implementations = new List<T>();
            //TODO: perform checks to ensure type is valid
            foreach (var file in System.IO.Directory.GetFiles(directory))
            {
                //TODO: add proper file handling here and limit files to check
                //try/catch added in place of ensure files are not .dll
                try
                {
                    foreach (var type in System.Reflection.Assembly.LoadFile(file).GetTypes())
                    {
                        if (interfaceType.IsAssignableFrom(type) && interfaceType != type)
                        { 
                            //found class that implements interface
                            //TODO: perform additional checks to ensure any
                            //requirements not specified in interface
                            //ex: ensure type is a class, check for default constructor, etc
                            T instance = (T)Activator.CreateInstance(type);
                            implementations.Add(instance);
                        }
                    }
                }
                catch { }
            }
            return implementations;
        }
