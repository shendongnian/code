    [AttributeUsage(AttributeTargets.Class)]
    public class ClientAttribute : Attribute
    {
        private string _name;
        private string _description;
        private string _resourceName;
        private Bitmap _icon;
        public string Name { get { return this._name; } }
        public string Description { get { return this._description; } }
        public Bitmap Icon { get { return this._icon; } }
        public ClientAttribute(string name, string description, string resourceName = null)
        {
            _name = name;
            _description = description;
            _resourceName = resourceName;
        }
        public void ResolveResource(Assembly assembly)
        {
            if (assembly != null && _resourceName != null)
            {
                var stream = assembly.GetManifestResourceStream(_resourceName);
                if (stream != null)
                    _icon = new Bitmap(stream);
            }
        }
    }
