 csharp
using System;
using System.Buffers;
using System.Runtime.InteropServices;
class Program
{
    static void Main()
    {
        Memory<byte> bytes = new byte[1024];
        Memory<ushort> typed = Utils.Cast<byte, ushort>(bytes);
        Console.WriteLine(typed.Length); // 512
        // note CPU endianness matters re the layout
        typed.Span[0] = 0x5432;
        Console.WriteLine(bytes.Span[0]); // 50 = 0x32
        Console.WriteLine(bytes.Span[1]); // 84 = 0x54
    }
}
static class Utils
{
    public static Memory<TTo> Cast<TFrom, TTo>(Memory<TFrom> from)
        where TFrom : unmanaged
        where TTo : unmanaged
    {
        // avoid the extra allocation/indirection, at the cost of a L0 box
        if (typeof(TFrom) == typeof(TTo)) return (Memory<TTo>)(object)from;
        return new CastMemoryManager<TFrom, TTo>(from).Memory;
    }
    private sealed class CastMemoryManager<TFrom, TTo> : MemoryManager<TTo>
        where TFrom : unmanaged
        where TTo : unmanaged
    {
        private readonly Memory<TFrom> _from;
        public CastMemoryManager(Memory<TFrom> from) => _from = from;
        public override Span<TTo> GetSpan()
            => MemoryMarshal.Cast<TFrom, TTo>(_from.Span);
        protected override void Dispose(bool disposing) { }
        public override MemoryHandle Pin(int elementIndex = 0)
            => throw new NotSupportedException();
        public override void Unpin()
            => throw new NotSupportedException();
    }
}
If you really want to support pin/unpin, that should be possible - you'll just need to compute the relative ranges and offsets from the competing `TFrom`/`TTo`, though - presumably using `Unsafe.SizeOf<T>` etc, and using `MemoryMarshal.TryGetMemoryManager` to get the underlying memory manager (if one - note that naked arrays don't have a memory manager). Unless you're going to extensively test that option, throwing is probably safer than getting it wrong.
