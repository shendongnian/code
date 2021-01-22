        enum MyEnum
        {
            A, B, C, D
        }
        // ...
        MyEnum e = MyEnum.A;
        if (new []{ MyEnum.A, MyEnum.B }.Contains(e))
           Console.WriteLine("Yeah!");
