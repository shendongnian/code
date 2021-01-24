    public MyContentPage : ContentPage
    {
        private INetwork _network;
        private IDialog _dialog;
        public MyContentPage(INetwork network, IDialog dialog)
        {
            //..
            _network = network;
            _dialog = dialog;
        }
    }    
    public Network(ILog log)
    {
        public bool HasConnectivity() { ... }
    }
