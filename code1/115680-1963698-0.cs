    class NewClass : IMessage
    {
        #region IMessage Members
    
        internal bool Check()
        {
            //Some logic
        }
        bool IMessage.Check()
        {
            return this.Check();
        }
    }
