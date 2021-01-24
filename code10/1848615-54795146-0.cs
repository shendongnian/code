cs
T ReadOptional<T>() where T : IEntity, new()
{
    if (ReadBoolean())
    {
        T instance = new T();
        instance.Read(this); // IEntity method
        return instance;
    }
    else
    {
        return default!; // <-- note the exclamation mark
    }
}
