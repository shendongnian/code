    using System;
    
    public class Propertier {
    	public string ReadOnlyPlease { get; private set; }
    
    	public Propertier()  { ReadOnlyPlease="As initialised"; }
    	public void Method() { ReadOnlyPlease="This might be changed internally"; }
    	public override string ToString() { return String.Format("[{0}]",ReadOnlyPlease); }
    }
    
    public class Program {
    	static void Main() {
    		Propertier p=new Propertier();
    		Console.WriteLine(p);
    
    //		p.ReadOnlyPlease="Changing externally!";
    //		Console.WriteLine(p);
    
		    // error CS0272: The property or indexer `Propertier.ReadOnlyPlease' cannot be used in this context because the set accessor is inaccessible
    		// That's good and intended.
    
    		// But...
    		p.Method();
    		Console.WriteLine(p);
    	}
    }
