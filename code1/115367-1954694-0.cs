    public interface IFreezable
    {
        bool CanFreeze
        {
            get;
        }
        bool IsFrozen
        {
            get;
        }
    
        void Freeze();
    }
