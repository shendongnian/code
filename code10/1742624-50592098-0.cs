      public class SomeClass
    {
        public SomeClass(Action<Action<bool>, Action<bool>> func)
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
