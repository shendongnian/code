    public class Test {
    	
    }
    
    void Main()
    {
    	object x = Enumerable.Range(0,100).Select(_ => new Test()).Take(15);
    	List<Test> fail = (List<Test>)x; // InvalidCastException: Unable to cast object of type '<TakeIterator>d__25`1[UserQuery+Test]' to type 'System.Collections.Generic.List`1[UserQuery+Test]'.
    	List<Test> pass = ((IEnumerable<Test>)x).ToList(); // No problem
    }
