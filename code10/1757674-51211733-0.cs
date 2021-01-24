		public interface IA
		{
		}
		public abstract class A : IA
		{
			protected abstract void Append();
		}
		public class B : A
		{
			protected override void Append()
			{
				//override definition
			}
		}
		public class MyClass : B
		{
			//Here I want to change the definition of Append method.
			//You can do is hide the method by creating a new method with the same name
			public new void Append() { }
		}
