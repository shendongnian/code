    public class User
    {        
        public void DoSomething()
        {
           Something...
        }
    }
    public class Manager
    {
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        public override void DoSomething()
        { }
    }
    void main()
    {
       User user = new User();
       user.DoSomething();
       Manager manager = new Manager();
       manager.DoSomething(); // --------- This row will throw a compile time error
    }
