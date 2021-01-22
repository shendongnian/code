    /// <summary>
    /// Tests the <see cref="CachedEnumerable{T}"/> class.
    /// </summary>
    [TestFixture]
    public class CachedEnumerableTest {
      private int _count;
      /// <remarks>
      /// This test case is only here to emphasise the problem with <see cref="IEnumerable{T}"/> which <see cref="CachedEnumerable{T}"/> attempts to solve.
      /// </remarks>
      [Test]
      [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
      [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
      public void MultipleEnumerationAreNotCachedForOriginalIEnumerable() {
        _count = 0;
        var enumerable = Enumerable.Range(1, 40).Select(IncrementCount);
        enumerable.Take(3).ToArray();
        enumerable.Take(10).ToArray();
        enumerable.Take(4).ToArray();
        Assert.AreEqual(17, _count);
      }
      /// <remarks>
      /// This test case is only here to emphasise the problem with <see cref="IList{T}"/> which <see cref="CachedEnumerable{T}"/> attempts to solve.
      /// </remarks>
      [Test]
      [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
      [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
      public void EntireListIsEnumeratedForOriginalListOrArray() {
        _count = 0;
        Enumerable.Range(1, 40).Select(IncrementCount).ToList();
        Assert.AreEqual(40, _count);
        _count = 0;
        Enumerable.Range(1, 40).Select(IncrementCount).ToArray();
        Assert.AreEqual(40, _count);
      }
      [Test]
      [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
      public void MultipleEnumerationsAreCached() {
        _count = 0;
        var cachedEnumerable = Enumerable.Range(1, 40).Select(IncrementCount).ToCachedEnumerable();
        cachedEnumerable.Take(3).ToArray();
        cachedEnumerable.Take(10).ToArray();
        cachedEnumerable.Take(4).ToArray();
        Assert.AreEqual(10, _count);
      }
      [Test]
      public void FreshCachedEnumerableDoesNotEnumerateExceptFirstItem() {
        _count = 0;
        Enumerable.Range(1, 40).Select(IncrementCount).ToCachedEnumerable();
        Assert.AreEqual(1, _count);
      }
      /// <remarks>
      /// Based on Jon Skeet's test mentioned here: http://www.siepman.nl/blog/post/2013/10/09/LazyList-A-better-LINQ-result-cache-than-List.aspx
      /// </remarks>
      [Test]
      [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
      public void MatrixEnumerationIteratesAsExpectedWhileStillKeepingEnumeratedValuesCached() {
        _count = 0;
        var cachedEnumerable = Enumerable.Range(1, 5).Select(IncrementCount).ToCachedEnumerable();
        var matrixCount = 0;
        foreach (var x in cachedEnumerable) {
          foreach (var y in cachedEnumerable) {
            matrixCount++;
          }
        }
        Assert.AreEqual(5, _count);
        Assert.AreEqual(25, matrixCount);
      }
      [Test]
      public void OrderingCachedEnumerableWorksAsExpectedWhileStillKeepingEnumeratedValuesCached() {
        _count = 0;
        var cachedEnumerable = Enumerable.Range(1, 5).Select(IncrementCount).ToCachedEnumerable();
        var orderedEnumerated = cachedEnumerable.OrderBy(x => x);
        var orderedEnumeratedArray = orderedEnumerated.ToArray(); // Enumerated first time in ascending order.
        Assert.AreEqual(5, _count);
        for (int i = 0; i < orderedEnumeratedArray.Length; i++) {
          Assert.AreEqual(i + 1, orderedEnumeratedArray[i]);
        }
        var reorderedEnumeratedArray = orderedEnumerated.OrderByDescending(x => x).ToArray(); // Enumerated second time in descending order.
        Assert.AreEqual(5, _count);
        for (int i = 0; i < reorderedEnumeratedArray.Length; i++) {
          Assert.AreEqual(5 - i, reorderedEnumeratedArray[i]);
        }
      }
      private int IncrementCount(int value) {
        _count++;
        return value;
      }
    }
