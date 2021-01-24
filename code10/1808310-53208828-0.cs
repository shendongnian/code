                LogManager.Info("Starting REST Endpoint...");
                try
                {
                    _httpHost = new HttpHost(
                        Config.ReadSetting("HttpHost", "localhost"),
                        Config.ReadSetting("HttpPort", 8081),
                        Config.ReadSetting("RestEnvironment", "Development"));
                    _httpHost.Start();
                    LogManager.Info("REST Endpoint started");
                }
                catch (Exception e)
                {
                    LogManager.Error($"Failed to start REST endpoint: {e}");
                }
                LogManager.Info("Starting Monitors...");
                // Set up dependency tree.
                Container _container = new Container();
                BootstrapDependencyInjectionTree.Bootstrap(_container);
                _container.Verify();
                _monitors = new Monitors(_container.GetInstance<IMonitorDefinitionRepository>());
                _monitors.RegisterMonitors();
                _monitors.StartContinuousMonitors();
