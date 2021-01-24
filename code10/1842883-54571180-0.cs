    static void RunLoop(int depth, int from, int to, Action<int, int[]> callback)
    {
        int[] tokens = new int[depth];
        int counter = 0;
        RunLoop(tokens, 0, from, to, callback, ref counter);
    }
    private static void RunLoop(int[] tokens, int index, int from, int to,
        Action<int, int[]> callback, ref int counter)
    {
        int nextIndex = index + 1;
        for(int i = from; i < to; i++)
        {
            tokens[index] = i;
            if (nextIndex == tokens.Length)
            {
                callback(counter, tokens);
                counter++; // post-increment when invoking the callback
            }
            else
            {
                counter++; // pre-increment when diving
                RunLoop(tokens, nextIndex, i + 1, to + 1, callback, ref counter);
            }
        }
    }
