    public interface IMeasurement<PARAMTYPE> where PARAMTYPE : Parameters
    {
        void Init();
        void Close();
        void Setup(PARAMTYPE p);
    }
    public abstract class Parameters
    {
    }
