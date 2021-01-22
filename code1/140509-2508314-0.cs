    public interface IJobDoer
    {
        void DoJob();
        Guid Guid{get;}
    }
    public class FirstJobType : IJobDoer
    {
        void DoJob()
        {
         /// whatever...
        }
        Guid Guid { get{return "insert-guid-here";}}
    }
    
