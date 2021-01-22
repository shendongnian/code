        public static bool IsRunningInVisualStudioDesigner
        {
            get
            {
                // Are we looking at this dialog in the Visual Studio Designer or Blend?
                string appname = System.Reflection.Assembly.GetEntryAssembly().FullName;
                return appname.Contains("XDesProc");
            }
        }
