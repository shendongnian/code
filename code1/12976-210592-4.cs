    public FunkyUserControl : UserControl
    {
        private List<UserControl> subscribedControls;
    
        public List<UserControl> Subscribers
        {
            get { return subscribedControls;}
        }
    
        public void SubscribeTo(UserControl control)
        {
            subscribedControls.Add(control);
        }
    }
