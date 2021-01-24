    public class YourDllCalculation
    {
        // In the .NET Framework class library, events are based on the EventHandler delegate and the EventArgs base class.
        // So we create delegate using our newly created class to represents it like EventHandler
        public delegate void ResultChangeEventHandler(object sender, CustomEventArgs e);
        // Now we create our event
        public event IzborRobeEventHandler ResultChanged;
        // Local storing variable
        private int Result = 0;
        // This is method from which you inform event something changed and user listening to event catch EventArgs passed (in our case our CustomEventArgs)
        protected virtual void OnResultChange(CustomEventArgs e)
        {
            ResultChangeEventHandler h = ResultChanged;
            if (h != null)
                h(this, e);
        }
        // We will use this method from new code to start calculation;
        public void StartCalculation()
        {
            // Calculation will be done in separate thread so your code could proceed further if needed
            Thread t1 = new Thread(Calculate);
            t1.Start();
        }
        private void Calculate()
        {
            for(int i = 0; i < 100; i++)
            {
                OnResultChange(new CustomEventArgs() { OldResult = i, NewResult = i + 1 });
                Result = i;
                Thread.Sleep(1000); // Pause thread from running for 1 sec
            }
        }
    }
