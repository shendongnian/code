    void Main()
    {	
    	var a = new Test();
    	var b = a;
    	var c = new Test();
    	
    	Object.Equals(a,b);//True
    	Object.Equals(b,c);//False
    	Object.Equals(a,c);//False
    	Object.ReferenceEquals(a,b);//True
    	Object.ReferenceEquals(b,c);//False
    	Object.ReferenceEquals(a,c);//False
    
    	var d = M(a);//Pass a to M and check the identity of what comes back
    
    	Object.ReferenceEquals(a, d);//True
    }
    
    public static Test M(Test e)
    {
    	e.SomeVariable = 10;//a and e now refer to the same object location
    	//e = new Test();//a and e refer to different objects when you do this.  This will not be reflected back to the caller unless you use ref parameters
    	return e;
    }
    
    public class Test { public int SomeVariable {get;set;} }
