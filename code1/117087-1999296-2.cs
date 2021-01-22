    class MyBaseClass
    {
    public:
        virtual void writeSomething() = 0;
    };
    
    class DerivedClass1 : public MyBaseClass
    {
    public:
        virtual void writeSomething()
        {
            Writeln("something else here  1");
        }
    };
    class DerivedClass2 : public MyBaseClass
    {
    public:
        virtual void writeSomething()
        {
            Writeln("something else here  2");
        }
    };
