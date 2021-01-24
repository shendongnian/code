    public class P2 : P1
    {
        // Changed type parameter name from C2 to T for clarity
        public override void Run<T>(T c) 
        {
            c.c1Prop = 1;
            c.c2Prop = 2;
        }
    }
