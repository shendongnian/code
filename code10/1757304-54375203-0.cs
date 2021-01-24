        private void RunPhotoShopAction(string sFile)
        {
            Type PhotoshopType = Type.GetTypeFromProgID("Photoshop.Application");
            dynamic appRef = Activator.CreateInstance(PhotoshopType);
            appRef.Open(sFile);
            appRef.DoAction("HoodBW","HoodMain" );   // ActionSet,Action
            appRef.ActiveDocument.Close();
            appRef.Quit();
            appRef = null;
        }
