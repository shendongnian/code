    public class X2 : X
    {
        public X2()
        {
        }
        protected override void OnEvent(EventArgs e)
        {
            // Do something before the event
            base.OnEvent(e);
            // Do something after the event
        }
    }
