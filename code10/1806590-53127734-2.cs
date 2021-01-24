    interface IMyLovelyHorse {...}
    
    public class MyGreenHorse : IMyLovelyHorse {...}
    
    public class MyYellowHorse : IMyLovelyHorse {...}
    
    public class MyLittleHorse : IMyLovelyHorse {...}
    
    ...
    
    public override IMyLovelyHorse CreateMyHorse(sometype somevalue)
    {  
        switch(sometype)
        {
            case "MyGreenHorse" : return new MyGreenHorse();
            ...
        }
    }
