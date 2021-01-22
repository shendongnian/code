    public interface IBase<TM, TPkey> 
        where TM : bType
        where TPkey : new ()        
    {
        TM Get(TPkey key);
    }
    
    public interface IABase<TPK> : IBase<ConcreteTmA, TPK> {}
    public interface IBBase<TPK> : IBase<ConcreteTmB, TPK> {}
    public class Root <TPK> :
        IABase<TPK>,
        IBBase<TPK> 
        where TM : MType 
        where TPM : PMType 
        where TPK : new()
    {
        ConcreteTmA IABase.Get(TPK key)
        {
        }
        ConcreteTmB IBBase.Get(TPK key)
        {
        }
    }
