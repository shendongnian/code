    internal interface InternalIAM
    {
        void Save();
    }
    public class concreteIAM : InternalIAM
    {
        void InternalIAM.Save()
        {
        }
    }
