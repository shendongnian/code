        public delegate void Action(TYPE_OF_ESB esb, TYPE_OF_CONTACT_FOLDER contact folder);
        private static void Process(Action action)
        {
            using (var esb = ExchangeService.GetExchangeServiceBinding())
            {
                var contactFolder = FolderService.GetPublicFolder(esb, Properties.Settings.Default.ExchangePublicFolderName);
                action(esb, contactfolder);
            }
        }
    Process((esb, contactfolder)=>processFolderDelegate(esb, contactFolder));
    Process((esb, contactfolder)=>processContactDelegate(esb, contactFolder, contact));
    
