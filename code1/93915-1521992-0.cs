    public class SomeOtherClass
    {
        public event EventHandler SomeEvent;
        public void ClearSomeEvent()
        {
            foreach (EventHandler e in SomeEvent.GetInvocationList())
            {
                SomeEvent -= e;
            }
        }
    }
