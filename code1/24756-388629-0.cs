    public void Foo()
    {
        MyClass myObject = new MyClass();
        myObject.Name = "Dog";
        Bar(myObject);
        Console.WriteLine(myObject.Name); // Writes "Cat".
    }
    public void Bar(MyClass someObject)
    {
        someObject.Name = "Cat";
    }
