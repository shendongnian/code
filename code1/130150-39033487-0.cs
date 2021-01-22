    Assembly assembly = Assembly.LoadFrom(file);
                        Directory.SetCurrentDirectory(Path.GetDirectoryName(file));
                        Type[] types = assembly.GetTypes();
                        foreach (Type t in types)
                        {
                            MethodInfo method = t.GetMethod("Main", BindingFlags.Static | BindingFlags.NonPublic);
                            if (method != null)
                            {
                                try
                                {
                                  method.Invoke(null, null);
                                }
