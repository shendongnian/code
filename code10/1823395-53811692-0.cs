    // This is valid: T in IEnumerable<T> is covariant
    public interface ILinkedTabularSectionManager<out T1> where T1 : TabularBusinessObject
    {
        T1 LinkedTabularBusinessObject { get; }
        IEnumerable<T1> DataSource { get; }
    }
    // This is invalid: T in BindingList<T> is invariant
    public interface ILinkedTabularSectionManager<out T1> where T1 : TabularBusinessObject
    {
        T1 LinkedTabularBusinessObject { get; }
        BindingList<T1> DataSource { get; }
    }
    // This is invalid: T in Action<T> is contravariant
    public interface ILinkedTabularSectionManager<out T1> where T1 : TabularBusinessObject
    {
        T1 LinkedTabularBusinessObject { get; }
        Action<T1> SomeAction { get; }
    }
