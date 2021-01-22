    private void AddListenerToConfiguration<T>(FluentConfiguration config, params ListenerType[] typesForListener)
            where T : class
        {
            var listener = Activator.CreateInstance<T>();
            config.ExposeConfiguration(x =>
                {
                    foreach (var listenerType in typesForListener)
                    {
                        x.AppendListeners(listenerType, new object[]
                        {
                            listener
                        });
                    }
                });
        }
