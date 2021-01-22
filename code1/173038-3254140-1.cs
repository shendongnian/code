    class MyClass
    {
        int something = 10;
        void MyMethod()
        {
            int something = 0;
            //...lots'a code here...
            something = 20;  //Which var is something pointing at?
        }
    }
