	public class Foo : IDisposable {
		public void SendWait(string keys) {
			SendKeys.SendWait(keys);
		}
		public void Dispose() { }
	}
