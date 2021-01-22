public class A
{
    public A() // constructor
    {
        protected static B b = new B(processResult1, processResult2);
    }
    private void processResult1(string result)
    {
        // come here when result is successful
    }
    private void processResult2(string result)
    {
        // come here when result is failed
    }
    static void main()
    {
        b.DoJobHelper(...);
    }
}
public class B
{
    private com.nowhere.somewebservice ws;
    private Action&lt;string> success;
    private Action&lt;string> failure;
    public B(Action&lt;string> success, Action&lt;string> failure)
    {
        this.success = success;
        this.failure = failure;
        this.ws = new com.nowhere.somewebservice();
        ws.JobCompleted += new JobCompletedEventHandler(OnCompleted);
    }
    void OnCompleted(object sender, JobCompletedEventArgs e)
    {
        string s;
        Guid taskID = (Guid)e.UserState;
        //this switch will never do anything because s is null right now.
        //you'll need to check some actual state, or translate some other
        //state into the "Success" and "Failure" words for the s variable
        //before you call this switch statement.
        switch (s)
        {
             case "Success":
             {    
               success(s);
               break;
             }
             case "Failed":
             {
               failure(s);
               break;
             }
             default: break;
        }
    }
    public void DoJobHelper()
    {
        Object userState = Guid.NewGuid();
        ws.DoJob(..., userState);
    }        
}
