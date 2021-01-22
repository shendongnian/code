        /// <summary>
        /// public GUID property for use in static class </summary>
        /// <returns> 
        /// Returns the application GUID or null if unable to get it. </returns>
        static public string AssemblyGuid
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
                if (attributes.Length == 0) { return String.Empty; }
                return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value.ToUpper();
            }
        }
