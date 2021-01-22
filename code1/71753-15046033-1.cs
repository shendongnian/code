    class Widget //Some Class "Widget"
    {
        int _size;
        int _length;
    // Declaring a Constructor, observe the Return type is not required
        
    public Widget(int length)
        {
            this._length = length;
        }
    // Declaring a Method, Return type is Mandator
        public void SomeMethod(int size)
        {
            this._size = size;
        }
    }
    //Calling the Constructor and Method
    class Program
    {
        static void Main()
        {
    //Calling the Constructor, Observe that it can be called at the time the Object is created
            Widget newObject = new Widget(124);
    //Calling the Method, Observe that the Method needs to be called from the New  Object which has been created. You can not call it the way Constructor is called.
            newObject.SomeMethod(10);I
           
        }
    }
