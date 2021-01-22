    MyClass c = new MyClass(); c.MyProperty = "foo";
    
    CNull(c); // only a copy of the reference is sent 
    Console.WriteLine(c.MyProperty); // still foo, we only made the copy null
    CPropertyChange(c); 
    Console.WriteLine(c.MyProperty); // bar
    
    
    private void CNull(MyClass c2)
            {          
                c2 = null;
            }
    private void CPropertyChange(MyClass c2) 
            {
                c2.MyProperty = "bar"; // c2 is a copy, but it refers to the same object that c does (on heap) and modified property would appear on c.MyProperty as well.
            }
