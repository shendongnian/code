    public interface IFlyable { void fly(); }
    public interface ISwimmable { void swim(); }
    public interface IVoteable { void vote(); }
    
    public abstract class Animal
    {
        public abstract void Accept(AnimalVisiter Visitor);
        //some common behaviour is here
        public bool LegsKicking { get; set; }
        public bool ArmsFlapping { get; set; }
    }
    
    //This class now absorbs new responisbilities, so base class doesn't have to
    public class AnimalVisiter
    {
        public void Visit(ISwimmable Subject)
        {
            Subject.swim();
        }
    
        public void Visit(IVoteable Subject)
        {
            Subject.vote();
        }
    
        public void Visit(IFlyable Subject)
        {
            Subject.fly();
        }
    }
    
    public class SwimmingHuman : Animal, ISwimmable
    {
        public void swim()
        {
            LegsKicking = true;
        }
    
        public override void Accept(AnimalVisiter Visitor)
        {
            Visitor.Visit(this);
        }
    }
    
    public class VotingHuman : Animal, IVoteable
    {
      
        public override void Accept(AnimalVisiter Visitor)
        {
            Visitor.Visit(this);
        }
    
        public void vote()
        {
            VoteCast = true;
        }
        //some specific behaviour goes here
        public bool VoteCast { get; set; }
    }
    
    public class SwimmingTiger : Animal, ISwimmable
    {
     
        public void swim()
        {
            LegsKicking = true;
            //also wag tail, flap ears
        }
    
        public override void Accept(AnimalVisiter Visitor)
        {
            Visitor.Visit(this);
        }
    }
