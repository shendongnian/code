	class Program {
		static void Main(string[] args) {
			using (SomeClass sc = new SomeClass())
			{
				string str = sc.DoSomething();
				sc.BlowUp();
			}
		}
	}
	public class SomeClass : IDisposable {
		private System.IO.StreamWriter wtr = null;
		public SomeClass() {
			string path = System.IO.Path.GetTempFileName();
			this.wtr = new System.IO.StreamWriter(path);
			this.wtr.WriteLine("SomeClass()");
		}
		public void BlowUp() {
			this.wtr.WriteLine("BlowUp()");
			throw new Exception("An exception was thrown.");
		}
		public string DoSomething() {
			this.wtr.WriteLine("DoSomething()");
			return "Did something.";
		}
		public void Dispose() {
			this.wtr.WriteLine("Dispose()");
			this.wtr.Dispose();
		}
	}
