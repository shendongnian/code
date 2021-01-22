    public class EventQueueTests
    {
        public void Test1()
        {
            Action myAction = () => Console.WriteLine("foo");
            myAction += () => Console.WriteLine("bar");
            myAction();
            //foo
            //bar
        }
        public void Test2()
        {
            Action<int> myAction = x => Console.WriteLine("foo {0}", x);
            myAction += x => Console.WriteLine("bar {0}", x);
            myAction(3);
            //foo 3
            //bar 3
        }
        public void Test3()
        {
            Func<int, int> myFunc = x => { Console.WriteLine("foo {0}", x); return x + 2; };
            myFunc += x => { Console.WriteLine("bar {0}", x); return x + 1; };
            int y = myFunc(3);
            Console.WriteLine(y);
            //foo 3
            //bar 3
            //4
        }
    }
