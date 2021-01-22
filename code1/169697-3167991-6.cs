    public class Parent
    {
        public Parent()
        {
            AttachEventsToThings();
        }
    
        protected virtual void AttachEventsToThings()
        {
            AnObject.ThisEvent += EventRaised;
            AnObject.ThatEvent += EventRaised;
        }
    
        public virtual void EventRaised(object pSender, EventArgs pArguments)
        {
            MessageBox.Show("EventRaised");
        }
    }
    
    public class Child : Parent
    {
        protected override void AttachEventsToThings()
        {
            AnotherObject.ThisEvent += EventRaised;
            AnotherObject.ThatEvent += EventRaised;
        }
    }
