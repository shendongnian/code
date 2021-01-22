    public interface IConfig
    {
        // Other configuration properties removed for examp[le
        /// <summary>
        /// Script fragments
        /// </summary>
        string Scripts[string name] { get; set; }
    }
    /// <summary>
    /// Class to handle loading and saving the application's configuration.
    /// </summary>
    internal class Config : IConfig, IXmlConfig
    {
      #region Application Configuraiton Settings
        // Other configuration properties removed for examp[le
        /// <summary>
        /// Script fragments
        /// </summary>
        public string Scripts[string name]
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    string script;
                    if (_scripts.TryGetValue(name.Trim().ToLower(), out script))
                        return script;
                }
                return string.Empty;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    _scripts[name.Trim().ToLower()] = value;
                    OnAppConfigChanged();
                }
            }
        }
        private readonly Dictionary<string, string> _scripts = new Dictionary<string, string>();
      #endregion
        /// <summary>
        /// Clears configuration settings, but does not clear internal configuration meta-data.
        /// </summary>
        private void ClearConfig()
        {
            // Other properties removed for example
            _scripts.Clear();
        }
      #region IXmlConfig
        void IXmlConfig.XmlSaveTo(int configVersion, XElement appElement)
        {
            Debug.Assert(configVersion == 2);
            Debug.Assert(appElement != null);
            // Saving of other properties removed for example
            if (_scripts.Count > 0)
            {
                var scripts = new XElement("Scripts");
                foreach (var kvp in _scripts)
                {
                    var scriptElement = new XElement(kvp.Key, kvp.Value);
                    scripts.Add(scriptElement);
                }
                appElement.Add(scripts);
            }
        }
        void IXmlConfig.XmlLoadFrom(int configVersion, XElement appElement)
        {
            // Implementation simplified for example
            Debug.Assert(appElement != null);
            ClearConfig();
            if (configVersion == 2)
            {
                // Loading of other configuration properites removed for example
                var scripts = appElement.Element("Scripts");
                if (scripts != null)
                    foreach (var script in scripts.Elements())
                        _scripts[script.Name.ToString()] = script.Value;
            }
            else
                throw new ApplicaitonException("Unknown configuration file version " + configVersion);
        }
      #endregion
    }
