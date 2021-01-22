    public abstract class A
    {
        public void display() { }
    }
    
    public class B : A
    {
        public override void display()
        {
            base.display();
        }
    
        public void someothermethod()
        {
            this.display();
        }
    }
