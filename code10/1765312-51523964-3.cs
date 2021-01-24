    public void Original()
    {
        float[] result = new float[16384];
        System.Threading.Tasks.Parallel.For(0, 16384, x =>
        {
            int[] histogram = new int[32768]; // allocation and initialization with all 0's, no?
            for (int i = 0; i < histogram.Length; i++)
            {
                histogram[i] = some_func(); // each element in histogram[] is written anew
            }
            result[x] = do_something_with(histogram);
        });
    }
