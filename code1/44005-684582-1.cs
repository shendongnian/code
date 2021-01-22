    public class AccountBasic : Account
    { 
       public override int AccountId  { get; set; }
       //implement the rest
    }
    public class AccountExtra : Account
    {
       public override int AccountId  { get; set; }
       //your extra details
       public int Period { get; set; }
       public int Visitors { get; set; }
       public string ContactName { get; set; }
    }
