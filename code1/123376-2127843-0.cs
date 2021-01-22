static readonly Func&lt;Type, uint> SizeOfType = (Func&lt;Type, uint>)Delegate.CreateDelegate(typeof(Func&lt;Type, uint>), typeof(Marshal).GetMethod("SizeOfType", BindingFlags.NonPublic | BindingFlags.Static));
static void Write&lt;T1, T2>(T1 item1, T2 item2)
    where T1 : struct
    where T2 : struct
{
    using (MemoryMappedFile file = MemoryMappedFile.CreateNew(null, 32))
    using (MemoryMappedViewAccessor accessor = file.CreateViewAccessor())
    {
        accessor.Write(0, ref item1);
        accessor.Write(SizeOfType(typeof(T1)), ref item2);
    }
}
