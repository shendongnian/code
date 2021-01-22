    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            DateTime now = System.DateTime.Now;
            DateTime future = new DateTime(2010, 1, 1);
            Console.WriteLine((now - dt).TotalSeconds);
            Console.WriteLine((future - dt).TotalSeconds);
