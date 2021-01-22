    public class Class1 
    {
        bool myBool { get; set; }
        void changeBoolFunc(bool val) { myBool = val; }
        public Class1() 
        {
            Action<bool> changeBoolAction = changeBoolFunc;
            myBool = true; 
            Console.WriteLine(myBool);    // outputs "True"
            Class2 c2 = new Class2(changeBoolAction);
            Console.WriteLine(myBool);    // outputs "False"
        }
    }
    public class Class2
    {
        public Class2(Action<bool> boolChanger) { boolChanger(false); }
    }
    void Main()
    {
        Class1 c1 = new Class1();
    }
