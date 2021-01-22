    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void TestHeapBySorting()
        {
            var minHeap = new MinHeap<int>(new[] {9, 8, 4, 1, 6, 2, 7, 4, 1, 2});
            AssertHeapSort(minHeap, minHeap.OrderBy(i => i).ToArray());
            minHeap = new MinHeap<int> { 7, 5, 1, 6, 3, 2, 4, 1, 2, 1, 3, 4, 7 };
            AssertHeapSort(minHeap, minHeap.OrderBy(i => i).ToArray());
            var maxHeap = new MaxHeap<int>(new[] {1, 5, 3, 2, 7, 56, 3, 1, 23, 5, 2, 1});
            AssertHeapSort(maxHeap, maxHeap.OrderBy(d => -d).ToArray());
            maxHeap = new MaxHeap<int> {2, 6, 1, 3, 56, 1, 4, 7, 8, 23, 4, 5, 7, 34, 1, 4};
            AssertHeapSort(maxHeap, maxHeap.OrderBy(d => -d).ToArray());
        }
        private static void AssertHeapSort(Heap<int> heap, IEnumerable<int> expected)
        {
            var sorted = new List<int>();
            while (heap.Count > 0)
                sorted.Add(heap.ExtractDominating());
            Assert.IsTrue(sorted.SequenceEqual(expected));
        }
    }
