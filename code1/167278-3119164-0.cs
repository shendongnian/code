    public class ServerControl1 : WebControl
    {
       public CompositeItem Composite { get; set; }
        public ServerControl1()
        {
            Composite = new CompositeItem();
        }
    }
    public class CompositeItem
    {
        public bool ItemOne { get; set; }
        public string ItemTwo { get; set; }
        public int ItemThree { get; set; }
    }
