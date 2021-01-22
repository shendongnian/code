    public class Something
    {
        public event EventHandler SomethingHappened;
    }
    public class SomethingConsumer
    {
        private mySomething = new Something();
        public void WireUpEvents()
        {
            mySomething.SomethingHappened += whenSomethingHappened;
        }
        private void whenSoemthingHappened(object sender, EventArgs e)
        {
            // do something
        }
    }
