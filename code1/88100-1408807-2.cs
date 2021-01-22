    public class TimeoutMock : ITimeout
    {
        public bool TimeoutExpired;
    
        public bool CheckTimeout(int timeout)
        {
            return TimeoutExpired;
        }
    }
