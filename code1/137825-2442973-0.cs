            Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                if (type.Namespace.Equals("TestApp") &&
                    (type.GetInterface("System.IDisposable") != null))
                {
                    object obj = Activator.CreateInstance(type);
                    if (obj is Form)
                        ((Form)obj).ShowDialog();
                }
            }
