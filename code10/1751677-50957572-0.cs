    //This reserves a memory location to store a reference to an ArrayList
    private static ArrayList obj;  
    public static ArrayList GetObj()
    {
        try
        {
            //This instantiates a new ArrayList and stores a reference to it in obj
            obj = new ArrayList();
            //This creates a copy of the value stored in obj and returns it to the caller by pushing it onto the stack. 
            return obj;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            //This sets the reference stored in obj to null. This does not affect the copy of the reference that was pushed onto the stack
            obj = null;
        }
    }
    public static void SomeMethod()
    {
        //This reserves a different memory location that can store a reference to an ArrayList.
        //Note that this exists in parallel with the static field named obj
        ArrayList obj;
        //This retrieves the reference to the ArrayList that was pushed onto the stack and stores it in the local (not static) variable obj
        obj = Example.GetObj(); 
    }
