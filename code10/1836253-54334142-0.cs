cs
    interface ITest
    {
        Span<byte> Data { get; }
    }
    unsafe struct TestStruct : ITest
    {
        fixed byte dataField[8];
        public Span<byte> Data
        {
            get
            {
                //Unsafe.AsPointer() to avoid the fixed expression :-)
                return new Span<byte>(Unsafe.AsPointer(ref dataField[0]), 8);
            }
        }
    }
    class Program
    {
        //Note: This test is done in Debug mode to make sure the string allocation isn't ommited
        static void Main(string[] args)
        {
            new string('c', 200);
            //Boxes the struct onto the heap.
            //The object is allocated after the string to ensure it will be moved during GC compacting
            ITest HeapAlloc = new TestStruct();
            Span<byte> span1, span2;
            span1 = HeapAlloc.Data; //Creates span to old location
            GC.Collect(2, GCCollectionMode.Forced, true, true); //Force a compacting garbage collection
            span2 = HeapAlloc.Data; //Creates span to new location
            //Ensures that if the pointer to span1 wasn't updated, that there wouldn't be heap corruption
            //Write to Span2
            span2[0] = 5;
            //Read from Span1
            Console.WriteLine(span1[0] == 5); //Prints true in .NET Core 2.1, span1's pointer is updated
        }
    }
What I've learned from my research into the IL, please forgive me if I'm not explaining this correctly:
.NET Core's 2 Field Span:
cs
//Note, this is not the complete declaration, just the fields
public ref readonly struct Span<T>
{
    internal readonly ByReference<T> _pointer;
    private readonly int _length;
}
.NET Framework's 3 Field Span:
cs
//Same note as 2 Field Span
public ref readonly struct Span<T>
{
    private readonly Pinnable<T> _pinnable;
    private readonly IntPtr _byteOffset;
    private readonly int _length;
}
.Net Core is using the 2 field model of Span. Due to the .NET Framework using the 3 field model, It's pointer will not be updated. The reason? The `Span<T>(void* pointer, int length)` constructor (which I am using for this) for the 3 field span sets the `_byteOffset` field with the `pointer` argument. The pointer in the 3 field span that would be updated by the GC is the `_pinnable` field. With the 2 field Span, they are the same.
So, the answer to my question is, yes I can have a Span point to a fixed buffer with or without a fixed statement, but its dangerous to do this at all when not using .NET Core's 2 field Span Model. Correct me if I'm wrong about .NET Framework's current Span model.
