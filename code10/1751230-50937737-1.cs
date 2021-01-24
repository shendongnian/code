            ClassA obj2 = obj;
            Console.WriteLine(object.ReferenceEquals(obj, obj2)); // true
            obj2.a = 5;
            Console.WriteLine(obj.a); // also 5
            ClassA obj3 = new ClassA(obj);
            Console.WriteLine(object.ReferenceEquals(obj, obj3)); // false
            obj3.a = 15;
            Console.WriteLine(obj.a); // still 5 
