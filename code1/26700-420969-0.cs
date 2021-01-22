        private static void WhatAmI<T>() where T : new()
        {
            T x = new T();
            Console.WriteLine("T is: " + typeof(T).FullName);
            Console.WriteLine("x is: " + x.GetType().FullName);
        }
