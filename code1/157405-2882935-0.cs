    public interface ICountable<out T>  
    {
        int Count{ get; }
    }
    public class MyCollection : ICountable<string>, ICountable<FileStream>
    {  
        int ICountable<string>.Count
        {
            get { return 1; }
        }
        int ICountable<FileStream>.Count
        {
            get { return 2; }
        }
    }
