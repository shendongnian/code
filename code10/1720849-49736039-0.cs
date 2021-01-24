    public abstract class BaseFieldValue 
    {
    }
    public abstract class BaseFieldValue<ToutputType,TinputType> : BaseFieldValue
    {
       public abstract ToutputType DoStuff(TinputType input);
    }
