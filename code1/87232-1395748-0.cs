    public class DoMath
    {
        private int Add2(int piNumber)
        {
            return piNumber + 2; 
        }
        private int Divideby7(int piNumber)
        {
            return Divideby7(this.Add2(piNumber));
        }
    }
