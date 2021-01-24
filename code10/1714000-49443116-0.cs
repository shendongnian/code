        //-------------------------------------------------------------
        public string GetAppVersion()
        //-------------------------------------------------------------
        {    
            return NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();    
        }
