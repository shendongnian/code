    public interface IStoppable {
        void Stop();
    }
    public class MoreWork: IStoppable {
        bool isStopping = false;
        public void Stop() { isStopping = true; }
        public void DoMoreWork() {
            do {
                // More work here
            } while (!isStopping);
        }
    }
