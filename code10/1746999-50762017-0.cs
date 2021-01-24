    public abstract class BaseCamera<TEventArgs> where TEventArgs : EventArgs
    {
        public delegate void FrameArivedEventHandler(object sender, TEventArgs e); //errors
        public virtual event FrameArivedEventHandler FrameArivedEvent; //seams fine
        protected void Trigger(TEventArgs eventArgs)
        {
            FrameArivedEvent(this, eventArgs);
        }
    }
    public abstract class FrameArivedEventArgs : EventArgs
    {
        public int counter;
        public byte[] RawRGB;
    }
    public class NikonCamera : BaseCamera<NikonFrameArrivedEventArgs>
    {
        public override event FrameArivedEventHandler FrameArivedEvent
        {
            // Override whatever
            add => base.FrameArivedEvent += value;
            remove => base.FrameArivedEvent -= value;
        }
    }
    public class NikonFrameArrivedEventArgs : FrameArivedEventArgs
    {
        public string Message { get; set; }
    }
    public class TestExampleUsageClass
    {
        public TestExampleUsageClass()
        {
            var camera = new NikonCamera();
            camera.FrameArivedEvent += MyTestClassFrameArrivedEventHandler;
        }
        private void MyTestClassFrameArrivedEventHandler(object sender, NikonFrameArrivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
