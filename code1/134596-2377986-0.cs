    public class MotionDetector
    {
        private IFrameGroupListener m_listener;
        public MotionDetector(IFrameGroupListener listener)
        {
            m_listener = listener;
        }
        public void NewFrame(Frame f)
        {
            if(DetectMotion(f))
            {
                var group = GetCaptureGroup();
                m_listener.ReceiveFrameList(group);
            }
        }
    }
    public interface IFrameGroupListener
    {
        void ReceiveFrameList(IList<Frame> captureGroup);
    }
    public class FramePump
    {
        private MotionDetector m_detector;
        public FramePump(MotionDetector detector)
        {
            m_detector = detector;
        }
        public void DoFrame()
        {
            Frame f = GetFrameSomehow();
            m_detector.NewFrame(f);
        }
    }
