    bool[] bools = ...
    Array.Reverse(bools); // NOTE: this modifies your original array
    BitArray a = new BitArray(bools);
    byte[] bytes = new byte[a.Length / 8];
    a.CopyTo(bytes, 0);
    Array.Reverse(bytes);
