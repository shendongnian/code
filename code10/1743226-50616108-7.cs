    public class EventSubscriber
    {
        string currentData = "";
        public EventSubscriber(string data)
        {
            currentData = data;
        }
        public void eventPublisher_HeavyLogicDone(object sender, EventArgs e)
        {
            if(e.subScriberSpecificData == currentData)
            {
               //Do further task which is dependant to result of logic
               //if now subscriber doesn't need to listen this event anymore
               ((EventPublisher)sender).HeavyLogicDone -= eventPublisher_HeavyLogicDone;
            }
        }
    }
