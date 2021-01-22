    public interface IProvider
    {
      int Number {get;set;}
    }
    
    public class Config
    {
         public int GetNumber<T>() where T : IProvider
         {
             // code to find the provider you want
             IProvider foundProvider = ProviderFactoryMethodHere(typeof(T));
             return foundProvider.Number;
         }
    }
