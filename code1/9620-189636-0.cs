		public sealed class JustFather : Father<JustFather> {}
		
		public class Father<T> where T : Father<T>
		{ public virtual T SomePropertyName
			{ get { return (T) this; }
			}
		}
		
		public class Child : Father<Child>
		{ public override Child SomePropertyName
			{ get { return  this; }
			}
		}
