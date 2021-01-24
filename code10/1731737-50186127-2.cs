    public class SomeAlsVariableImpl : IAlsVariable
    {
        public string Name {get;}
    
        public event EventHandler<YourEventArgs> YourEvent;
    
        //  Call this method any time you need to raise the event.
        private void RaiseYourEvent(int opcVariableVtqValue)
        {
            YourEvent?.Invoke(this, new YourEventArgs 
            {
                 Name = Name,
                 OpcVariableVtqValue = opcVariableVtqValue,
            }
        }
    }  
