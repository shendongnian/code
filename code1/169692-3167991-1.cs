    public class Subscriber
    {
        bool m_Active = true;
        public virtual void EventRaised(object pSender, EventArgs pArguments)
        {
            if(m_Active) { InnerEventRaised(pSender, pArguments); }
        }
        void InnerEventRaised(object pSender, EventArgs pArguments)
        {
            Console.WriteLine("EventRaised");
        }
        public virtual void UnsubscribeAll()
        {
            m_Active = false;
        }
    }
