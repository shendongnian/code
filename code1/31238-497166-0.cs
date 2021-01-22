    public class Animal { }
    public class Zebra : Animal { }
    public class Zoo
    {
        public void ShowZebraCast()
        {
            Animal a = new Animal();
            Zebra z = (Zebra)a;
        }
    }
