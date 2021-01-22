    public class AppleFactory : IAppleFactory
    {
       public IApple Create()
       {
          return new Apple();
       }
    }
