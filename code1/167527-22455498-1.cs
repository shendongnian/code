    var wpfAssembly = (AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(item => item.EntryPoint != null)
                    .Select(item => 
                        new {item, applicationType = item.GetType(item.GetName().Name + ".App", false)})
                    .Where(a => a.applicationType != null && typeof(System.Windows.Application)
                        .IsAssignableFrom(a.applicationType))
                        .Select(a => a.item))
                .FirstOrDefault();
