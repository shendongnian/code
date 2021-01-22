            object obj_a, obj_b;
            string str_a, str_b;
            str_a = "ABC";
            str_b = new string("ABC".ToCharArray());
            obj_a = str_a;
            obj_b = str_b;
            Console.WriteLine("str_a == str_b = {0}", str_a == str_b); // in string == operator is overloaded
            Console.WriteLine("str_a.Equals(str_b) = {0}", str_a.Equals(str_b)); // string overrides Object.Euqals
            Console.WriteLine("obj_a == obj_b = {0}", obj_a == obj_b); // in object == operator is not overloaded
            Console.WriteLine("obj_a.Equals(obj_b) = {0}", obj_a.Equals(obj_b)); // Object.Equesl is virtual and overridden method from string will be executed.
            Console.ReadKey();
