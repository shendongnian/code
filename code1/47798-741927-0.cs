    public enum ReturnFaiz
    {
        Empty = -1,
        faiztype1=20,
        faiztype2=30,
        faiztype3=40
    }
    public class ConcreteHandler2 : Handler
    {
        public override ReturnFaiz HandleRequest(int mevduat)
        {
            if (mevduat > 1000 && mevduat < 3000)
            {
              return ReturnFaiz.faiztype2;
            }
            else if (BirSonrakiAdim != null)
            {
                BirSonrakiAdim.HandleRequest(mevduat);
            }
            else
                return ReturnFaiz.faiztype1;
            return ReturnFaiz.Empty; // default return value if nothing else applies.
        }
    }
