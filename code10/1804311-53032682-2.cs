    public class ChocolateFactory
    {
    
        public string ChocolateType { get; set; }
        public int CocoaAmount { get; set; }
        public List<string> Materials {get;set;} = new List<string>();
        public override string ToString()
        {
            return $"Chocolate type: {ChocolateType} | Materials: {string.Join(", ", Materials)} | Cocoa amount: {CocoaAmount}%, IsPremium=No";
            
        }
    }
    public class PremiumChocolateFactory : ChocolateFactory
    {
        public override string ToString()
        {
            return $"Chocolate type: {ChocolateType} | Materials: {string.Join(", ", Materials)} | Cocoa amount: {CocoaAmount}%, IsPremium=Yes";
    
        }
    }
