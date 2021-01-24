      public class SomeClass
    {
        public SomeClass(Action<Action<bool>, Action<bool>> func)
        {
        func(
                (i) =>{
                    Func1(i);
                },
                (j) =>
                {
                    Func2(j);
                });
           
        }
        public void Func1(bool cool)
        {
        }
        public void Func2(bool cool)
        {
        }
        public static void Main()
        {
            var someClass = new SomeClass((func1, func2) =>
              {
                  var cool = true;
                  if (cool)
                  {
                      func1(cool);
                  }
                  else
                  {
                      func2(cool);
                  }
              });
        }
    }
