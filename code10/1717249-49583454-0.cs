      static class Mixin {
        public static IObservable<T> CatchAndStop<T>(this IObservable<T> source) 
          => source.Catch((Exception exc) => Observable.Empty<T>());
      }
      [TestClass]
      public class ReactiveExtensions {
        [TestMethod]
        public void ReactiveCatch() {
          var source = new[] { new { i = 1 }, new { i = 0 } }.ToObservable();
          var a = source
            .Do(x => { var j = 1 / x.i; })
            .CatchAndStop()
            .ToEnumerable()
            .ToArray();
          Assert.AreEqual(new { i = 1 }, a[0]);
        }
