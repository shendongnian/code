    public class MyObject : MyParentObject { 
    
    int x; 
    int y; 
    int z; 
    
    public MyObject() { 
        x = 5; 
        y = 10; 
    } 
    
    public MyObject(int num) : this() { 
        z = num; 
    }
