    public abstract class P1<T> where T : C1
    {
        public abstract void Run(T c);
    }
    
    public class P2 : P1<C2>
    {
        public override void Run(C2 c) 
        {
            c.c1Prop = 1; //Is recognized
            c.c2Prop = 2; //Is NOT recognized and is an error
        }
    }
