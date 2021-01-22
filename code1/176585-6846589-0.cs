    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Calc: ICalc
    { 
    }
    var calc = new Calc();
    var h1 = new ServiceHost(calc, baseAddress1);
    var h2 = new ServiceHost(calc, baseAddress2);
