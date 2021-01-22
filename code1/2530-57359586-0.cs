       public IList<T> GetClassByType<T>()
       {
            return AppDomain.CurrentDomain.GetAssemblies()
                              .SelectMany(s => s.GetTypes())
                              .ToList(p => typeof(T)
                              .IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)
                              .SelectList(c => (T)Activator.CreateInstance(c));
       }
