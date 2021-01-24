    public interface IDynamicValue
    {
        object Get(Context context);
    }
    public interface IDynamicValue<out T>
    {
        T Get(Context context);
    }
