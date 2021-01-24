    public class MyBroadcastReceiver
    {
        // Constructor
        public MyBroadcastReceiver() {}
        // property 
        public MyMainClass {get;set;}
    }
    public MyMainClass 
    {
        private void CreateBroadcastReceiver()
        {
            var br = new MyBroadcastReceiver();
            br.MyMainClass = this;
        } 
    }
