    public class MyClassWithNonFieldLikeEvent
    {
       private CustomEventHandler m_delegate;
    
       public void Subscribe(CustomEventHandler handler) 
       {
          m_delegate += handler;        
       }
    
       public void Unsubscribe(CustomEventHandler handler)
       {          
          m_delegate -= handler;
       }
       private void DoSomethingThatRaisesEvent()
       {
          m_delegate.Invoke(...);
       }       
    }
