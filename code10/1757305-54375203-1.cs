        using Photoshop;  //Adobe Photoshop CC 2014 Object Library
        private void RunPhotoShopAction(string sFile,string ActionSet, String ActionName)
        {
            Photoshop.Application appRef = new Photoshop.Application();
            appRef.Open(sFile);
            appRef.DoAction(ActionSet, ActionName);   
            appRef.ActiveDocument.Close();
        }
