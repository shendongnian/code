    [
        ComVisible(true),
        Guid(<some guid>),
        InterfaceType(ComInterfaceType.InterfaceIsDual)
    ]
    public interface IDeclarations : IEnumerable
    {
        [DispId(0)]
        Declaration Item(int Index);
        [DispId(1)]
        int Count { get; }
        [DispId(-4)]
        IEnumerator _GetEnumerator();
     }
