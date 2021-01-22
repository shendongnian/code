    public static class Signal
    {
        public static EventHandler OnSignal {get;set}
        public static void SendSignal()
        {
            if (OnSignal !=null) OnSignal(this,new EventArgs());
        }
    }
    
