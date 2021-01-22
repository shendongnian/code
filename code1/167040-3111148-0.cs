    /// <summary>
    /// Provides methods to load plugins from external assemblies.
    /// </summary>
    public static class PluginLoader
    {
        ...
        /// <summary>
        /// Loads the plugins from a specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly from which to load.</param>
        /// <returns>The plugin factories contained in the assembly, if the load was successful; null, otherwise.</returns>
        public static IEnumerable<IPluginFactory> LoadPlugins(Assembly assembly)
        {
            var factories = new List<IPluginFactory>();
            try
            {
                foreach (var type in assembly.GetTypes())
                {
                    IPluginEnumerator instance = null;
                    if (type.GetInterface("IPluginEnumerator") != null)
                    {
                        instance = (IPluginEnumerator)Activator.CreateInstance(type);
                    }
                    if (instance != null)
                    {
                        factories.AddRange(instance.EnumerateFactories());
                    }
                }
            }
            catch (SecurityException ex)
            {
                throw new LoadPluginsFailureException("Loading of plugins failed.  Check the inner exception for more details.", ex);
            }
            catch (ReflectionTypeLoadException ex)
            {
                throw new LoadPluginsFailureException("Loading of plugins failed.  Check the inner exception for more details.", ex);
            }
            return factories.AsReadOnly();
        }
    }
