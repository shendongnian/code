    public abstract class CustomerBase
    {
        public CustomerBase(string name)
        {
            Name = name;
        }
        public abstract string Type { get;}
        public string Name { get; }
    }
    public class GoldCustomer : CustomerBase
    {
        public GoldCustomer(string name)
          : base(name)
        {
        }
        public override string Type => "Gold";
    }
    public class SilverCustomer : CustomerBase
    {
        public SilverCustomer(string name)
          : base(name)
        {
        }
        public override string Type => "Silver";
    }
