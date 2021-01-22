    static IEnumerable<bool> UnpackBools(IEnumerable<byte> bytes, int paddingEnd = 0)
    {
        using (var enumerator = bytes.GetEnumerator()) {
            bool last = !enumerator.MoveNext();
            while (!last) {
                byte current = enumerator.Current;
                last = !enumerator.MoveNext();
                for (int i = 0; i < 8 - (last ? paddingEnd : 0); i++) {
                    yield return (current & (1 << i)) != 0;
                }
            }
        }
    }
