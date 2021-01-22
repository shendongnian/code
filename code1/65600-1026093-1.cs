    namespace CarStuff
    {
       class Car : ICar
       {
          public int MakeId { get {...} set { ... } }
          // no Make property...
          public string Registration { get { ... } set { ... } }
          public int CurrentOwnerId { get { ... } set { ... } }
          public IPerson CurrentOwner { get { ... } }
       }
    }
    namespace MakeExts
    {
       class ResolveMake
       {
          public static IMakeInfo Make(this Car myCar)
          {
             //implementation here
          }
       }
    }
