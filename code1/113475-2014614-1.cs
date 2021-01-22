    public void AddPluginToWorkspace(string pluginName)
        {
            PluginInfo pi = AvailablePlugins[pluginName];
            WorkspacePlugin wsp = new WorkspacePlugin();
            wsp.Name = pi.Name;
            wsp.CloseCommand = new DelegateCommand<object>(this.PluginClosing);
            wsp.SelectCommand = new DelegateCommand<object>(this.PluginSelected);
            wsp.id = System.Guid.NewGuid();
            this.modules.Add(wsp.id, wsp);
            var view = this.unityContainer.Resolve(pluginWindowType);
            if (view is IWorkspacePlugin)
            {
                var iwsp = view as IWorkspacePlugin;
                if (iwsp != null)
                {
                    iwsp.PluginID = wsp.id;
                }
            }
            else
            {
                throw new ArgumentException("Plugin view containers must implement IWorkspacePlugin.");
            }
            var workspaceRegion = regionManager.Regions["Workspace"];
            var pluginRegion = workspaceRegion.Add(view, wsp.id.ToString(), true);
            this.unityContainer.RegisterInstance<IRegionManager>(wsp.id.ToString(), pluginRegion);
            pluginRegion.Regions["PluginViewRegion"].Context = view;
            pluginRegion.Regions["PluginViewRegion"].Add(this.unityContainer.Resolve(pi.ViewType));
            this.eventAggregator.GetEvent<ActivePluginsChanged>().Publish(wsp);
        }  
