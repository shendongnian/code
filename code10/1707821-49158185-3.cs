    public class MyGeneric<T>
    {
    }
    
    void q49156521()
    {
    	var myObject = new MyGeneric<string>();
    	var myOtherObject = new MyGeneric<int>();
    }
