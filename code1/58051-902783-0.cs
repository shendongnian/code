    public interface IMyInterface{
        //...
    }
    public class Factory{
        public static IMyInterface GetObject(string param){
            // param is a parameter that will help the Factory decide what object to return
            // (that is only an example, there may not be any parameter at all)
        }
    }
    //...
    // You do not depend on a particular implementation here
    IMyInterface obj = Factory.GetObject("some param");
