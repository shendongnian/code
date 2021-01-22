	public class MyClass<TSelf> where TSelf: MyClass<TSelf> {
		public IEnumerable<T> GetControls<T>() where T: ControlBase {
		 // removed.
		}
		public void MyCall() {
			GetControls<HandleBase<TSelf>>(); 
		}
	}
	public class MyConcreteClass: MyClass<MyConcreteClass> {
	}
