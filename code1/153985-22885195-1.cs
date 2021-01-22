    public interface IConfig
    {
        // Other configuration properties removed for examp[le
        /// <summary>
        /// Script fragments
        /// </summary>
        ScriptsCollection Scripts { get; }
    }
    /// <summary>
    /// Class to handle loading and saving the application's configuration.
    /// </summary>
    internal class Config : IConfig, IXmlConfig
    {
        public Config()
        {
            _scripts = new ScriptsCollection();
            _scripts.ScriptChanged += ScriptChanged;
        }
      #region Application Configuraiton Settings
        // Other configuration properties removed for examp[le
        /// <summary>
        /// Script fragments
        /// </summary>
        public ScriptsCollection Scripts
        { get { return _scripts; } }
        private readonly ScriptsCollection _scripts;
        private void ScriptChanged(object sender, ScriptChangedEventArgs e)
        {
            OnAppConfigChanged();
        }
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
    public class ScriptsCollection : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly Dictionary<string, string> Scripts = new Dictionary<string, string>();
        public string this[string name]
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    string script;
                    if (Scripts.TryGetValue(name.Trim().ToLower(), out script))
                        return script;
                }
                return string.Empty;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(name))
                    Scripts[name.Trim().ToLower()] = value;
            }
        }
        public void Clear()
        {
            Scripts.Clear();
        }
        public int Count
        {
            get { return Scripts.Count; }
        }
        public event EventHandler<ScriptChangedEventArgs> ScriptChanged;
        protected void OnScriptChanged(string name)
        {
            if (ScriptChanged != null)
            {
                var script = this[name];
                ScriptChanged.Invoke(this, new ScriptChangedEventArgs(name, script));
            }
        }
      #region IEnumerable
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return Scripts.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      #endregion
    }
    public class ScriptChangedEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Script { get; set; }
        public ScriptChangedEventArgs(string name, string script)
        {
            Name = name;
            Script = script;
        }
    }
