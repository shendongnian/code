    interface IVisitor
    {
      void DoPigStuff(Piggy p);
      void DoDogStuff(Doggy d);
    }
    
    class GuiVisitor : IVisitor
    {
      void DoPigStuff(Piggy p)
      {
        label1.Text = String.Format("The pigs tail is {0}", p.TailLength);
      }
    
      void DoDogStuff(Doggy d)
      {
        Image1.src = d.Image;
      }
    }
    
    abstract class Animal
    {
        public String Name { get; set; }
        public abstract void Visit(IVisitor visitor);
    }
    
    class Piggy : Animal
    {
        public int TailLength { get; set; }
    
        public Piggy(int tailLength) 
        {
            Name = "Mr Pig";
            TailLength = tailLength;
        }
    
        public void Visit(IVisitor visitor)
        {
           visitor.DoPigStuff(this);
        }
    }
    
    class Doggy : Animal 
    {
       public String Image { get; set; }
    
       public Dog(String image) 
       {
         Name = "Mr Dog";
         Image = image;
       }
     
       public void Visit(IVisitor visitor)
       {
         visitor.DoDogStuff(this);
       }
    }
    
    public class AnimalProgram
    {
      static void Main(string[] args) {
        List<Animal> list = new List<Animal>();  
        Pig p = new Pig(5);  
        Dog d = new Dog("/images/dog1.jpg");  
        list.Add(p);  
        list.Add(d);
    
        IVisitor visitor = new GuiVisitor();  
        foreach (Animal a in list)   
        {
          a.Visit(visitor);
        }  
      }
    }
