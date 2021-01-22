    void Main()
    {
        var values = new Dictionary<string, int> { { "BaseValue", 1 }, { "DerivedValue", 2 } };
	
        Console.WriteLine(CreateObject<Base>(values).ToString());
	
        Console.WriteLine(CreateObject<Derived>(values).ToString());
    }
    public T CreateObject<T>(IDictionary<string, int> values)
        where T : Base, new()
    {
        var obj = new T();
        obj.Initialize(values);
        return obj;
    }
    public class Base
    {
        public int BaseValue { get; set; }
	
        public virtual void Initialize(IDictionary<string, int> values)
        {
            BaseValue = values["BaseValue"];
        }
	
        public override string ToString()
        {
            return "BaseValue = " + BaseValue;
        }
    }
    public class Derived : Base
    {
        public int DerivedValue { get; set; }
	
        public override void Initialize(IDictionary<string, int> values)
        {
            base.Initialize(values);
            DerivedValue = values["DerivedValue"];
        }
	
        public override string ToString()
        {		
            return base.ToString() + ", DerivedValue = " + DerivedValue;
        }
    }
