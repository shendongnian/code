            var data = new Dictionary<int, MulticastDelegate>();
            Action action1 = () => Console.WriteLine("abc");
            Action action2 = () => Console.WriteLine("def");
            data.AddOrAppend(1, action1);
            data.AddOrAppend(1, action2);
            data[1].DynamicInvoke();
