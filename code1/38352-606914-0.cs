    interface IIBCollection{
        IEnumerable<IB> IBs { get; }
    }
    // and in your implementation you can do
    IEnumerable<IB> IBs { 
        get { 
            foreach(IB ib in innerList) yield return ib; 
    }}
