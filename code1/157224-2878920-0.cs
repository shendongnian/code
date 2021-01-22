    public struct LikeEnum
    {
             
             public const string One = "One";
             public const string Two = "Two";
    
             private readonly string value;
    
             private LikeEnum(string value)
             {
                   this.value = value;
             }
    
             public static implicit operator LikeEnum(string value) {
                 return new LikeEnum(value);
             }
    
             public static implicit operator string(LikeEnum le) {
                 return le.value;
             }
    }
    //In the code
    LikeEnum le = new LikeEnum("One");
    switch(le) {
     case LikeEnum.One:
       //do something
       break;
    }
