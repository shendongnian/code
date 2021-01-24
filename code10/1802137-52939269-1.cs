    public class RunOp
    {
       
       private SemaphoreSlim slim = new SemaphoreSlim(1,1);
       //Has to do something with single instance
       Helper _configHelper;
       public async Task Run()
       {
          await slim.WaitAsync();
          _configHelper = new Helper();
          var val = await _configHelper.Process();
          Console.WriteLine(_configHelper.GetList.Count);
          slim.Release();
       }
       // or
       public async Task Run()
       {
          Helper configHelper = new Helper();
          var val = await configHelper.Process();
          Console.WriteLine(configHelper.GetList.Count);
       }
    }
         
