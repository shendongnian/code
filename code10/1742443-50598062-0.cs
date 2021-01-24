    public class SilencedEffect : ITemporaryEffect 
    {
        private long duration = 1000;
        private long endFrame;
        public SilencedEffect(int currentFrame)
        {
            endFrame = currentFrame + duration;
        }
        public bool IsActive(long currentFrame)
        {
            return endFrame > currentFrame;
        }
    }
