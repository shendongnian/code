    public interface IUser
    {
        IList<IJob> Jobs { get; set; }
    }
 
    public class User : IUser
    {
        IList<IJob> Jobs { get; set; }
        public User(IList<IJob> jobs)
        {
            Jobs = jobs; 
        }
    }
