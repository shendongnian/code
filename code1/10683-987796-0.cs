    public class Knife : ICut
    {
         public void Slice()
         {
              // slice something
         }
     
         void ICut.Cut()
         {
              Slice();
         }
    }
