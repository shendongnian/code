    private void Reverse()
    {
        const int extremelyLongWordLength = 100000;
        var tasks = new List<Task>();
        var wordStart = 0;
        var arr = "Hello how are you".ToCharArray();
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] == ' ')
            {
                var wordEnd = i - 1;
                if (wordEnd - wordStart >= extremelyLongWordLength)
                {
                    tasks.Add(ReverseWordAsTask(arr, wordStart, wordEnd));
                }
                else
                {
                    ReverseWord(arr, wordStart, wordEnd);
                }
                wordStart = i + 1;
            }
        }
        if (wordStart != arr.Length - 1)
        {
            if (arr.Length - 1 - wordStart > extremelyLongWordLength)
            {
                tasks.Add(ReverseWordAsTask(arr, wordStart, arr.Length - 1));
            }
            else
            {
                ReverseWord(arr, wordStart, arr.Length - 1);
            }
        }
        Task.WaitAll(tasks.ToArray());
        var modifiedString = new string(arr);
    }
    private static Task ReverseWordAsTask(char[] arr, int start, int end)
    {
        return Task.Run(() =>
        {
            var halfWordIndex = start + (end - start) / 2;
            for (var i = start; i < halfWordIndex; i++)
            {
                var temp = arr[i];
                var opposite = end - (i - start);
                arr[i] = arr[opposite];
                arr[opposite] = temp;
            }
        });
    }
    private static void ReverseWord(char[] arr, int start, int end)
    {
        var halfWordIndex = start + (end - start) / 2;
        for (var i = start; i < halfWordIndex; i++)
        {
            var temp = arr[i];
            var opposite = end - (i - start);
            arr[i] = arr[opposite];
            arr[opposite] = temp;
        }
    }
