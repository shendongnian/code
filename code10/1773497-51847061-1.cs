    public class InterleaveTests
    {
        private Action<int> act = x => { };
        public static int[][] CreateBuffers(int BufferCount, int BufferSize)
        {
            return Enumerable.Range(0, BufferCount)
                .Select(i => Enumerable.Range(0, BufferSize)
                    .Select(j => j * BufferCount + i).ToArray()).ToArray();
        }
        [Benchmark]
        [ArgumentsSource(nameof(MemoryNumbers))]
        public void InterleaveMemorySpan(Memory<int>[] data)
        {
            var rows = data.First().Length;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < data.Length; j++)
                    act(data[j].Span[i]);
        }
        [Benchmark]
        [ArgumentsSource(nameof(MemoryNumbers))]
        public unsafe void UnsafeInterleaveMemory(Memory<int>[] data)
        {
            var dataBuffers = stackalloc int*[data.Length];
            Pin(data.AsSpan(), 0);
            void Pin(Span<Memory<int>> buffers, int bufferIndex)
            {
                if (buffers.Length == 0)
                {
                    InterleaveMemory(data.First().Length, data.Length, dataBuffers);
                }
                else
                {
                    fixed (int* pData = buffers[0].Span)
                    {
                        dataBuffers[bufferIndex] = pData;
                        Pin(buffers.Slice(1), bufferIndex + 1);
                    }
                }
            }
            void InterleaveMemory(int rows, int columns, int** dataSpans)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        act(dataSpans[j][i]);
            }
        }
        [Benchmark]
        [ArgumentsSource(nameof(ArrayNumbers))]
        public void InterleaveArray(int[][] data)
        {
            var rows = data.First().Length;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < data.Length; j++)
                    act(data[j][i]);
        }
        public IEnumerable<int[][]> ArrayNumbers()
        {
            yield return CreateBuffers(16, 32 * 1024);
        }
        public IEnumerable<Memory<int>[]> MemoryNumbers()
        {
            yield return CreateBuffers(16, 32 * 1024).Select(x => x.AsMemory()).ToArray();
        }
    }
