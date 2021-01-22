    	public virtual void AsAString() {
    		BaseAsAString();
    	}
    	public virtual void BaseAsAString() {
    		Console.WriteLine("???");
    	}
    	public void example() {
    		this.AsAString();
    	}
    }
    
    public class A : Letter {
    	public override void AsAString() { Console.WriteLine("A"); }
    }
    A a = new A();
    a.AsAString(); //A
    a.BaseAsAString(); //???
