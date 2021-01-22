    public abstract class Turtle<T> where T : Turtle<T>
    {
        public abstract T Procreate();
    }
    
    public class SeaTurtle : Turtle<SeaTurtle>
    {
        public override SeaTurtle Procreate()
        {
            // ...
        }
    }
