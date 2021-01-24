    interface InterfaceA
    {
    	void MethodVisibleToB();
    }
    
    interface InterfaceB
    {
    	void MethodVisibleToA();
    }
    
    public class A : InterfaceA
    {
    	void InterfaceA.MethodVisibleToB() { }
    }
    public class B : InterfaceB
    {
    	void InterfaceB.MethodVisibleToA() { }
    }
