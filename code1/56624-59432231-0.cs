    //Events:
        public delegate void SomethingHappenedEventHandler(object sender, EventArgs args); //1. Define a delegate
        public static event SomethingHappenedEventHandler SomethingHappened;                  //2. Define an event based on that delegate
        private static void OnSomethingHappened()
        {
            Object sender = new Object();
            SomethingHappened?.Invoke(sender, EventArgs.Empty);                            //3. raise the event
