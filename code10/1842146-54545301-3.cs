    public class CarFactoryTests
    {  
      public class MoqCar : CarBase { }
      public void Register_WithValidParameters_DoesNotThrowException
      {
        // Act
        Assert.DoesNotThrow(() => CarFactory.Register<MoqCar>(
          nameof(Register_WithValidParameters_DoesNotThrowException)));
      }
      public void Create_WithValidCar_DoesNotThrowException
      {
        CarFactory.Register<MoqCar>(
          nameof(Create_WithValidParameters_DoesNotThrowException));
        Assert.DoesNotThrow(() => CarFactory.Create(
          nameof(Create_WithValidParameters_DoesNotThrowException));
      }
      // etc etc
    }
