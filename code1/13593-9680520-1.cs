            DateTime t = DateTime.Now;
            for (int i = 0; i < 1000000; i++)
            {
                Person<int> me = new Person<int>(1);
                int hey = me.Value;
            }
            long a = DateTime.Now.Ticks - t.Ticks;
            TimeSpan A = new TimeSpan(a);
            
            for (int i = 0; i < 1000000; i++)
            {
                Human per = new Human(1);
                object her = (object)per.Value;
            }
            long b = DateTime.Now.Ticks - t.Ticks;
            TimeSpan B = new TimeSpan(b);
            Console.WriteLine(A.ToString());
            Console.WriteLine(B.ToString());
            Console.ReadLine();
