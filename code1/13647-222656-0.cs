    class FooDto
     { public FooDto(Bar a, Bar b, Bar c) 
        { PropertyA = a;
          PropertyB = b;
          PropertyC = c;
        }
       public Bar PropertyA {get;set;}
       public Bar PropertyB {get;set;}
       public Bar PropertyC {get;set;}
     }
    class FooEditDto : FooDto
     { public FooEditDto(Bar a, Bar b, Bar c) : base(a,b,c)
       public Bar PropertyD {get;set;}
       public Bar PropertyE {get;set;}
     }
    public static Expression<Func<Foo, FooEditDto>> EditDtoSelector()
    {
        return f => new FooEditDto(f.PropertyA,f.PropertyB,f.PropertyC)
        {
            PropertyD = f.PropertyD,
            PropertyE = f.PropertyE
        };
    }
