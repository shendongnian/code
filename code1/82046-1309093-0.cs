        public delegate void Action();
        private static void Process(Action action)
        {
            using (var esb = ExchangeService.GetExchangeServiceBinding())
            {
                var contactFolder = FolderService.GetPublicFolder(esb, Properties.Settings.Default.ExchangePublicFolderName);
                action();
            }
        }
    Process(()=>processFolderDelegate(esb, contactFolder));
    Process(()=>processContactDelegate(esb, contactFolder, contact));
    
