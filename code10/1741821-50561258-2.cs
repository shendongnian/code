    public class PKRPKR
    {
        public int val { get; set; }
    }
    
    public class RootObject
    {
        public PKRPKR PKR_PKR { get; set; }
    }
    RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(json);
    Console.WriteLine(rootObject.PKR_PKR.val);
