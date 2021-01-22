            Console.WriteLine(TestEnum.Test1);//displays "TEST1"
            bool test = "TEST1" == TestEnum.Test1; //true
            var test2 = TestEnum.Test1; //is TestEnum and has value
            string test3 = TestEnum.Test1; //test3 = "TEST1"
            var test4 = TestEnum.Test1 == TestEnum.Test2; //false
            //TestEnum test5 = "string"; DOESN'T compile .... :(:(
