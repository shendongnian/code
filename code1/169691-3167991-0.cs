    public class Subscriber
    {
        bool m_Active = true;
        public virtual void EventRaised(object pSender, EventArgs pArguments)
        {
            m_InnerEvent(pSender, pArguments);
        }
        protected virtual void InnerEventRaised(object pSender, EventArgs pArguments)
        {
            Console.WriteLine("EventRaised");
        }
        public virtual void UnsubscribeAll()
        {
            m_InnerEvent -= InnerEventRaised;
        }
    }
