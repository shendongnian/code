    public class P2 : P1
    {
        public override void Run<T>(T c) 
        {
            c.c1Prop = 1; //Is recognized
            c.c2Prop = 2; //Is NOT recognized and is an error
        }
    }
