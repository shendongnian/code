    public abstract class NetworkJoin
    {
        internal NetworkJoin(){}
        string Name {get;set;}
        void Join();
    }
    public class DomainJoin : NetworkJoin
    {
        public DomainJoin() : base(){}
        string Name {get;set;}
        string Username {get;set;}
        SecureString {get;set;}
        void Join()
        {
            // Domain join code
        }
    }
    public class WorkgroupJoin : NetworkJoin
    {
        public WorkGroupJoin : base(){}
        string Name {get;set;}
        void Join()
        {
            // Workgroup join code
        }
     }
