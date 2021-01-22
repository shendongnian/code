            UnityContainer container = new UnityContainer();
            try
            {
                var section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
                if (section != null)
                {
                    section.Containers[0].Configure(container);
                }
            }
            catch (Exception ex)
            {
                TraceLogger.LogMessage("Configurarion Error for Unity Container", ex.Message, TraceEventType.Critical);
                Environment.Exit(1);
            }
            container.RegisterInstance(new DataContext());
            return container;
        }
