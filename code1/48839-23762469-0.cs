        public delegate void MyEventHaldler(object sender, EventArgs e);
    public class B
    {
        public virtual event MyEventHaldler MyEvent;
        protected override void OnChanged(EventArgs e)
        {
            if (MyEvent != null)
                MyEvent(this, e);
        }
    }
    public class D : B
    {
        public override event MyEventHaldler MyEvent;
        protected override void OnChanged(EventArgs e)
        {
            if (MyEvent != null)
                MyEvent(this, e);
        }
    }
