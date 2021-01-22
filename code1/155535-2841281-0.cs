    class Program {
    		static void Main(string[] args) {
    			Test test = new Test();
    			Console.WriteLine(test.Disposable == null);
    			GC.Collect();
    			Console.WriteLine(test.Disposable == null);
    			Console.ReadLine();
    		}
    	}
    
    	public class Test {
    		private WeakReference disposable = new WeakReference(new WeakDisposable());
    		public WeakDisposable Disposable {
    			get { return disposable.Target as WeakDisposable; }
    		}
    	}
    
    	public class WeakDisposable : IDisposable {
    		~WeakDisposable() {
    			Console.WriteLine("Destructor");
    		}
    		public void Dispose() {
    			Console.WriteLine("Dispose");
    		}
    	}
