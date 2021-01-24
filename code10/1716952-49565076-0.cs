    public class XYZ
    {
        private string[] x= new string[]{"smth", "smth"}; 
        [Receipt(order=1, name="warranty")]
        public string Receipt1 {get { return x[0];} set{x[0] = value;} }
        [Receipt(order=2, name="warranty")]
        public string Receipt2 {get { return x[1];} set{x[1] = value;} }
        //...  
    }
