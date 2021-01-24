    public interface IStudentFactory
    {
         IUser Create();
    }
    
    public class StudentFactory
    {
        public IUser Create() => new StudentContext();
    }
