    var unity = new UnityContainer();
    var unityConfig = new MyUnityConfig();
    unityConfig.RegisterTypes(unity);
    var p = (Program)unity.GetService(typeof(Program));
    p.MyFunc();
