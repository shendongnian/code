    public class MyClass
    {
       // now variables are at class level scope
       // all methods can access them now
       DateTime baslangicTarih;
       DateTime bitisTarih;
      public void MethodA()
      {
         baslangicTarih = DateTime.Now;
         bitisTarih = DateTime.Now;
         
      }
      public void MethodB()
      {
         baslangicTarih = DateTime.Now;
         bitisTarih = DateTime.Now;
      } 
    }
