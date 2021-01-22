    private void LoadTask(FileInfo dll)
        {
            Assembly assembly = Assembly.LoadFrom(dll.FullName);
            
            foreach (Type type in assembly.GetTypes())
            {
                var hasInterface = type.GetInterface("ITask") != null;
                
                if (type.IsClass && hasInterface)
                {
                    var instance = Activator.CreateInstance(type, _proxy, _context);
                    _tasks.Add(type.Name, (ITask)instance);
                }
            }
        }
