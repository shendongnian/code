    using System;
    namespace IdeaClass
    {
        class OtherClass
        {
            public delegate void DoThing(string text);
            public event DoThing ThingEvent;
            public void runThing(string text)
            {
                if (ThingEvent != null)
                {
                    ThingEvent(text);
                }
            }
        }
    }
