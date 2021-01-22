    using System;
    namespace IdeaClass
    {
        public class Ideas
        {
            static OtherClass oc = new OtherClass();
            public static void triggerMany()
            {
                oc.runThing("textual");
            }
            public Ideas()
            {
                Ideas.oc.ThingEvent += DoThingHandler;
            }
     
            public void DoThingHandler(string thing)
            {
                System.Console.WriteLine(thing);
            }
        }
    }
