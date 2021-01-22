    menuItem11.Text = Translator.GetString("New", "de-DE" );
...
        public static string GetString( string varname )
        {
            string resourceName = typeof(Vertaling).Namespace + ".Resources.MyResources";
            ResourceManager rm = new ResourceManager(resourceName, Assembly.GetExecutingAssembly());
            return rm.GetString(varname);
        }
        public static string GetString( string varname, string taalCode )
        {
            string resourceName = typeof(Vertaling).Namespace + ".Resources.MyResources";
            ResourceManager rm = new ResourceManager(resourceName, Assembly.GetExecutingAssembly());
            return rm.GetString(varname, new CultureInfo(taalCode) );
        }
