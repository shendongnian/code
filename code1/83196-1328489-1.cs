    private class MyObject
    {
        public bool Method1() { return true; } // Your own logic here
        public bool Method2() { return false; } // Your own logic here
    }
    
    private static bool MyFunction(Func<bool> methodOnObject)
    {
        bool returnValue = methodOnObject();
        return returnValue;
    }    
    
    private static void OverallFunction()
    {
        MyObject myObject = new MyObject();
    
        bool method1Success = MyFunction(myObject.Method1);
        bool method2Success = MyFunction(myObject.Method2);
    }
