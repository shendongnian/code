    class DoubleDispatchSample
    {
        static void Main(string[]args)
        {
            List<Animal> list = new List<Animal>();
            Pig p = new Pig(5);
            Dog d = new Dog(@"/images/dog1.jpg");
            list.Add(p);
            list.Add(d);
    
            Binder binder = new Binder(); // the class that knows how databinding works
    
            foreach (Animal a in list)
            {
                a.BindoTo(binder); // initiate the binding
            }
        }
    }
    
    class Binder
    {
        public void DoPigStuff(Pig p)
        {
            label1.Text = String.Format("The pigs tail is {0}", p.TailLength);
        }
    
        public void DoDogStuff(Dog d)
        {
            Image1.src = d.Image;
        }
    }
    
    internal abstract class Animal
    {
        public String Name
        {
            get;
            set;
        }
    
        protected abstract void BindTo(Binder binder);
    }
    
    internal class Pig : Animal
    {
        public int TailLength
        {
            get;
            set;
        }
    
        public Pig(int tailLength)
        {
            Name = "Mr Pig";
            TailLength = tailLength;
        }
    
        protected override void BindTo(Binder binder)
        {
            // Pig knows that it's a pig - so call the appropriate method.
            binder.DoPigStuff(this);
        }
    }
    
    internal class Dog : Animal
    {
        public String Image
        {
            get;
            set;
        }
    
        public Dog(String image)
        {
            Name = "Mr Dog";
            Image = image;
        }
    
        protected override void BindTo(Binder binder)
        {
            // Pig knows that it's a pig - so call the appropriate method.
            binder.DoDogStuff(this);
        }
    }
