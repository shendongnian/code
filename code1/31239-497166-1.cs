    public partial class Animal { }
    public class Zebra : Animal { }
    //in another file
    public partial class Animal{
      public Zebra ToZebra(){
        return new Zebra() { //set Zebra properties here.
        };
      }
    }
    public class Zoo
    {
        public void ShowZebraConvert()
        {
            Animal a = new Animal();
            Zebra z = a.ToZebra();
        }
    }
