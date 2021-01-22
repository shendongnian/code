// Class that represents the Service version of your app
public class serviceSample : ServiceBase
{
    protected override void OnStart(string[] args)
    {
        // Run the service version here 
        //  NOTE: If you're task is long running as is with most 
        //  services you should be invoking it on Worker Thread 
        //  !!! don't take to long in this function !!!
        base.OnStart(args);
    }
    protected override void OnStop()
    {
        // stop service code goes here
        base.OnStop();
    }
}
</pre>
    
