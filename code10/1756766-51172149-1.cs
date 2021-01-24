    public class myClassName{
    
    private readonly IDistributedCache _userCache;
    
    public  myClassName(IDistributedCache distributedCache) {
     _userCache = distributedCache;
    }
    
    public async Task FirstMethod(...)
    
    private async Task SecondMethod(...)
    
    }
    public class myClassNameTwo{
    
    private readonly myClassName _myClassName;
    
    public  myClassNameTwo(myClassName myClassName) {
     _myClassName= myClassName;
    }
    
    public async Task DummyMethod(){
     _myClassName.FirstMethod(...)
     }
    }
