    namespace test
    {
        using System;
        using net.sf.jni4net;
        using test;
        public class left : iright
        {
            public static void Main(String[] args)
            {
                left l = new left();
                l.sendMeToRight();
            }
            public left()
            {
                Console.WriteLine("left side constructed...");
            }
            public void sendMeToRight()
            {
                BridgeSetup bridgeSetup = new BridgeSetup();
                bridgeSetup.AddAllJarsClassPath(".");
                Bridge.CreateJVM(bridgeSetup);
                Bridge.RegisterAssembly(typeof(right).Assembly);
                Console.WriteLine("Sending myself to right.");
                right il = new right(this);
                il.announceMyself();
            }
            public void announceMyself()
            {
                Console.WriteLine("Hello from the left side...");
            }
        }
    }
