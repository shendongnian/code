    foreach (Type t in Assembly.GetCallingAssembly().GetTypes())
            {
                if (t.GetInterface("ITheInterface") != null)
                {
                    ITheInterface executor = Activator.CreateInstance(t) as ITheInterface;
                    executor.PerformSomething();
                }
            }
