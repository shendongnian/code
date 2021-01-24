    public interface IFactory<T>
    {
    	T CreateInstance();
    }    
    
        
    public interface ISomeClass
    {
    	int PropertyName { get; set; }
    	
    	void DoSomeImportantWork();	
    }
    
    
    internal SomeClass : ISomeClass, IFactory<ISomeClass>
    {
    
    	public int PropertyName { get; set; }
    		
    	public void DoSomeImportantWork()
    	{
    		// ...
    	}
    
    	public ISomeClass CreateInstance()
    	{
    		return new SomeClass();
    	}
    }
    
    public class MyClass
    {
    
        IFactory<ISomeClass> _exampleFactory;
    
    
        public MyClass(IFactory<ISomeClass> exampleFactory)
        {
            _exampleFactory = exampleFactory;
            MyMethod();
        }
    
    
        private void MyMethod()
        {
            for ( int index = 0 ; index < 5 ; index++ )
            {
                ISomeClass exampleName = _exampleFactory.CreateInstance();
                exampleName.PropertyName = index;
                exampleName.DoSomeImportantWork();
            }
        }
    }
