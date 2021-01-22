    public class ClassA : BaseClass
    {
       public override object PropertyA { get; set; }
    }
    
    public class ClassB: BaseClass
    {
        public override object PropertyB { get; set; }
    }
    
    public class BaseClass
    {
    	public virtual object PropertyA { get; set; }
    	public virtual object PropertyB { get; set; }
    }
    
    public void Main
    {
        List<BaseClass> MyList = new List<BaseClass>();
        ClassA a = new ClassA();
        ClassB b = new ClassB();
    
        MyList.Add(a);
        MyList.Add(b);
    
        for(int i = 0; i < MyList.Count; i++)
        {
         // Do something here with the Property
        	MyList[i].PropertyA;
        	MyList[i].PropertyB;      
        }
    }
