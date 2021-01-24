    public interface IFrameProvider {
        Frame CurrentFrame { get; }
    }
    public class DefaultFrameProvider : IFrameProvider {
        public Frame CurrentFrame {
            get {
                return (Window.Current.Content as Frame);
            }
        }
    }
    
