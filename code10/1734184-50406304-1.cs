    using System.Runtime.InteropServices;
    public Span<byte> AsSpan<T>(ref T val) where T : unmanaged
    {
        Span<T> valSpan = MemoryMarshal.CreateSpan(ref val, 1);
        return MemoryMarshal.Cast<T, byte>(valSpan);
    }
