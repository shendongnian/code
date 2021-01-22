    void MyMethod(int value, int otherValue)
    {
       // Do the work
    }
    void MyMethod(int value)
    {
       MyMethod(value, 0); // Do the defaulting by method overloading
    }
