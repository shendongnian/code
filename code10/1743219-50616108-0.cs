    public class EventPublisher
    {
        public event EventHandler HeavyLogicDone;
        public void ExposedMethod()
        {
            Thread logicCaller = new Thread(HeavyLogic);
            logicCaller.Start();
        }
        private void HeavyLogic()
        {
            //logic which may take time
            if (HeavyLogicDone != null)
                HeavyLogicDone(this, EventArgs.Empty);
        }
    }
