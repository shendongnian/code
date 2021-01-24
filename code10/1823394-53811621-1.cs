    public interface ILinkedTabularSectionManager<out T1> where T1 : TabularBusinessObject
    {
        T1 LinkedTabularBusinessObject { get; }
    
        IReadOnlyList<T1> DataSource { get; }
    }
