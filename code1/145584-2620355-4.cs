    using System;
    using System.Collections;
    [Serializable]
    public class Conversation
    {
        public Conversation(string convName, string convOwner)
        {
            this.convName = convName;
            this.convOwner = convOwner;
        }
        public Conversation()
        {
        }
        private string convName, convOwner;
        public ArrayList convUsers;
        public string getConvName()
        {
            return this.convName;
        }
        public string getConvOwner()
        {
            return this.convOwner;
        }
    }
