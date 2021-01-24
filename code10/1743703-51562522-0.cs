    private static unsafe string JoinInternal(ReadOnlySpan<char> first, ReadOnlySpan<char> second)
    {
        Debug.Assert(first.Length > 0 && second.Length > 0, "should have dealt with empty paths");
    
        bool hasSeparator = PathInternal.IsDirectorySeparator(first[first.Length - 1])
            || PathInternal.IsDirectorySeparator(second[0]);
    
        fixed (char* f = &MemoryMarshal.GetReference(first), s = &MemoryMarshal.GetReference(second))
        {
            return string.Create(
                first.Length + second.Length + (hasSeparator ? 0 : 1),
                (First: (IntPtr)f, FirstLength: first.Length, Second: (IntPtr)s, SecondLength: second.Length, HasSeparator: hasSeparator),
                (destination, state) =>
                {
                    new Span<char>((char*)state.First, state.FirstLength).CopyTo(destination);
                    if (!state.HasSeparator)
                        destination[state.FirstLength] = PathInternal.DirectorySeparatorChar;
                    new Span<char>((char*)state.Second, state.SecondLength).CopyTo(destination.Slice(state.FirstLength + (state.HasSeparator ? 0 : 1)));
                });
        }
    }
