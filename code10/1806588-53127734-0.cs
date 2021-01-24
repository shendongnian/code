    interface IMyLovelyHorse {...}
    
    public class MyGreenHorse : IMyLovelyHorse {...}
    
    public class MyYellowHorse : IMyLovelyHorse {...}
    
    public class MyLittleHorse : IMyLovelyHorse {...}
    
    ...
    
    public static IMyLovelyHorse CreateMyHorse(sometype somevalue)
    {  
        switch(sometype)
        {
            case "MyGreenHorse" : return new MyGreenHorse();
            ...
        }
    }
    ...
    var myHorse = Something.CreateMyHorse(somevalue);
    myHorse.Jump();
    // yehaaa
