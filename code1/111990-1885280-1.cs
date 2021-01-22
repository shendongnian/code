    public class AB : IA, IB { }
    void Method( ABWrapper x )
    {
    }
    void Main()
    {
        AB x = null;
        Method( (ABWrapper<AB>) x );
    }
