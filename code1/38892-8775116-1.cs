    class Ourself
    {
        public static string OurFileName() {
            System.Reflection.Assembly _objParentAssembly;
            if (System.Reflection.Assembly.GetEntryAssembly() == null)
                _objParentAssembly = System.Reflection.Assembly.GetCallingAssembly();
            else
                _objParentAssembly = System.Reflection.Assembly.GetEntryAssembly();
            if (_objParentAssembly.CodeBase.StartsWith("http://"))
                throw new System.IO.IOException("Deployed from URL");
            if (System.IO.File.Exists(_objParentAssembly.Location))
                return _objParentAssembly.Location;
            if (System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + System.AppDomain.CurrentDomain.FriendlyName))
                return System.AppDomain.CurrentDomain.BaseDirectory + System.AppDomain.CurrentDomain.FriendlyName;
            if (System.IO.File.Exists(System.Reflection.Assembly.GetExecutingAssembly().Location))
                return System.Reflection.Assembly.GetExecutingAssembly().Location;
            throw new System.IO.IOException("Assembly not found");
        }
    }
