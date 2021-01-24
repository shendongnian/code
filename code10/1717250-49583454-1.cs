      static class Mixin {
        public static IObservable<TSource> CatchAndStop<TSource>(
          this IObservable<TSource> source) => source.CatchAndStop(() => new Exception());
        public static IObservable<TSource> CatchAndStop<TSource, TException>(
          this IObservable<TSource> source, Func<TException> witness
          ) where TException : Exception
          => source.Catch((TException exc) => Observable.Empty<TSource>());
      }
      [TestClass]
      public class ReactiveExtensions {
        [TestMethod]
        public void ReactiveCatch() {
          var source = new[] { new { i = 1 }, new { i = 0 } }.ToObservable();
          var a = source
            .Do(x => { var j = 1 / x.i; })
            .CatchAndStop(() => new TimeoutException())
            .CatchAndStop()
            .ToEnumerable()
            .ToArray();
          Assert.AreEqual(new { i = 1 }, a[0]);
        }
