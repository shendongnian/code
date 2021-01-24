        //****************************************************
        class YourNameHelpers : IYourName
        //****************************************************
        {
            //-------------------------------------------------------------
            public string GetAppVersion()
            //-------------------------------------------------------------
            {
                Context context = Forms.Context;
                PackageManager manager = context.PackageManager;
                PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);
                return info.VersionName;
            }
        }
