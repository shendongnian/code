    Test test = new Test() {
    	new Test2() {
    		new Test3() {
    
    		}
    	},
    	new Test() {
    		new Test2() {
    			{ new Test(), new Test2() },
    			{ new Test(), new Test2() },
    			{ new Test(), new Test2() }
    		}
    	}
    };
    
    public class Test : IEnumerable
    {
    	public void Add(Test a){}
    	public void Add(Test2 a){}
    	public IEnumerator GetEnumerator(){}
    }
    
    public class Test2 : IEnumerable
    {
    	public void Add(Test a, Test2 b){}
    	public void Add(Test3 a){}
    	public IEnumerator GetEnumerator(){}
    }
    
    public class Test3 : IEnumerable
    {
    	public void Add(Test a)	{}
    	public void Add(Test2 a){}
    	public IEnumerator GetEnumerator(){}
    }
