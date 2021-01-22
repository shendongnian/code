    public class MyData<T, C>
        where T : IData<C>
    {
        public T Data { get; private set; }
        public MyData (T value)
        {
             Data = value;
        }
    }
    public interface IData<T>
    {
        T Data { get; set; }
        void SomeMethod();
    }
    //you'll need one of these for each data type you wish to support
    public class MyString: IData<string>
    {
       public MyString(String value)
       {
           Data = value;
       }
       
       public void SomeMethod()
       {
           //code here that uses _data...
           Console.WriteLine(Data);
       }
      
       public string Data { get; set; }
    }
