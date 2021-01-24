    public MyContentPage : ContentPage
    {
        private Network network;
        public MyContentPage()
        {
            //..
            network = new Network();
        }
    }
    public Network()
    {
        public bool HasConnectivity() { ... }
    }
