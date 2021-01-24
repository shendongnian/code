    public class EventPublisher
    {
        public event EventHandler HeavyLogicDone;
        public void ExposedMethod(string subScriberSpecificData)
        {
            Thread logicCaller = new Thread(() => HeavyLogic(subScriberSpecificData));
            logicCaller.Start();
        }
        private void HeavyLogic(string subScriberSpecificData)
        {
            //logic which may take time
            if (HeavyLogicDone != null)
                HeavyLogicDone(this, new EventArgsClass(subScriberSpecificData));
        }
    }
