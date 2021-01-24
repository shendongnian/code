    public abstract class GlobalTreeObjectImpl<T>
    {
        public bool Save()
        {
            return NeoStore.SaveGlobal(this);
        }
        
    public static T Get() => NeoStore.GetGlobal<T>();
        }
    }
