    #if NETCOREAPP3_0
    using System.Runtime.Intrinsics.X86;
    #endif
    …
    public static unsafe bool Compare(byte[] arr0, byte[] arr1)
    {
        if (arr0 == arr1)
        {
            return true;
        }
        if (arr0 == null || arr1 == null)
        {
            return false;
        }
        if (arr0.Length != arr1.Length)
        {
            return false;
        }
        if (arr0.Length == 0)
        {
            return true;
        }
        fixed (byte* b0 = arr0, b1 = arr1)
        {
    #if NETCOREAPP3_0
            if (Avx2.IsSupported)
            {
                return Compare256(b0, b1, arr0.Length);
            }
            else if (Sse2.IsSupported)
            {
                return Compare128(b0, b1, arr0.Length);
            }
            else
    #endif
            {
                return Compare64(b0, b1, arr0.Length);
            }
        }
    }
    #if NETCOREAPP3_0
    public static unsafe bool Compare256(byte* b0, byte* b1, int length)
    {
        byte* lastAddr = b0 + length;
        byte* lastAddrMinus128 = lastAddr - 128;
        const int mask = -1;
        while (b0 < lastAddrMinus128) // unroll the loop so that we are comparing 128 bytes at a time.
        {
            if (Avx2.MoveMask(Avx2.CompareEqual(Avx.LoadVector256(b0), Avx.LoadVector256(b1))) != mask)
            {
                return false;
            }
            if (Avx2.MoveMask(Avx2.CompareEqual(Avx.LoadVector256(b0 + 32), Avx.LoadVector256(b1 + 32))) != mask)
            {
                return false;
            }
            if (Avx2.MoveMask(Avx2.CompareEqual(Avx.LoadVector256(b0 + 64), Avx.LoadVector256(b1 + 64))) != mask)
            {
                return false;
            }
            if (Avx2.MoveMask(Avx2.CompareEqual(Avx.LoadVector256(b0 + 96), Avx.LoadVector256(b1 + 96))) != mask)
            {
                return false;
            }
            b0 += 128;
            b1 += 128;
        }
        while (b0 < lastAddr)
        {
            if (*b0 != *b1) return false;
            b0++;
            b1++;
        }
        return true;
    }
    public static unsafe bool Compare128(byte* b0, byte* b1, int length)
    {
        byte* lastAddr = b0 + length;
        byte* lastAddrMinus64 = lastAddr - 64;
        const int mask = 0xFFFF;
        while (b0 < lastAddrMinus64) // unroll the loop so that we are comparing 64 bytes at a time.
        {
            if (Sse2.MoveMask(Sse2.CompareEqual(Sse2.LoadVector128(b0), Sse2.LoadVector128(b1))) != mask)
            {
                return false;
            }
            if (Sse2.MoveMask(Sse2.CompareEqual(Sse2.LoadVector128(b0 + 16), Sse2.LoadVector128(b1 + 16))) != mask)
            {
                return false;
            }
            if (Sse2.MoveMask(Sse2.CompareEqual(Sse2.LoadVector128(b0 + 32), Sse2.LoadVector128(b1 + 32))) != mask)
            {
                return false;
            }
            if (Sse2.MoveMask(Sse2.CompareEqual(Sse2.LoadVector128(b0 + 48), Sse2.LoadVector128(b1 + 48))) != mask)
            {
                return false;
            }
            b0 += 64;
            b1 += 64;
        }
        while (b0 < lastAddr)
        {
            if (*b0 != *b1) return false;
            b0++;
            b1++;
        }
        return true;
    }
    #endif
    public static unsafe bool Compare64(byte* b0, byte* b1, int length)
    {
        byte* lastAddr = b0 + length;
        byte* lastAddrMinus32 = lastAddr - 32;
        while (b0 < lastAddrMinus32) // unroll the loop so that we are comparing 32 bytes at a time.
        {
            if (*(ulong*)b0 != *(ulong*)b1) return false;
            if (*(ulong*)(b0 + 8) != *(ulong*)(b1 + 8)) return false;
            if (*(ulong*)(b0 + 16) != *(ulong*)(b1 + 16)) return false;
            if (*(ulong*)(b0 + 24) != *(ulong*)(b1 + 24)) return false;
            b0 += 32;
            b1 += 32;
        }
        while (b0 < lastAddr)
        {
            if (*b0 != *b1) return false;
            b0++;
            b1++;
        }
        return true;
    }
