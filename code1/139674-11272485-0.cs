    MyClass CopyMyClassObject(MyClass obj1)
    {
        MyClass Result = new MyClass();
        Result.Value1 = obj1.Value1;
        Result.Value2 = obj1.Value2;
        //...
        Result Valuen = obj1.Valuen;
        Result.Object1.Value1 = obj1.Object1.Value1;
        Result.Object1.Value2 = obj1.Object1.Value2;
        //...
        Result.Object1.Valuen = obj1.Object1.Valuen;
        //..and so on until all values have been assigned
        //The actual assignments will use whatever methods are provided in MyClass, of course.
        return Result;
    }
