 - store instances of GeneralClass and SpecificClass in AbstractGeneralClass
 - access testAsClassA if you have a variable of type AbstractGeneralClass
 - access ClassB test if you have a variable of type SpecificClass 
	class ClassA { }
	class ClassB : ClassA { }
	abstract class AbstractGeneralClass
	{
		/* functionality that does not depend on test */
		
		public abstract ClassA testAsClassA { get; }
	}
	abstract class AbstractGeneralClass<T> : AbstractGeneralClass where T : ClassA
	{
		T myProperty;
		public T test
		{
			get { return myProperty; }
			set { myProperty = value; }
		}
		public override ClassA testAsClassA { get { return myProperty; } }
	}
	class GeneralClass : AbstractGeneralClass<ClassA> { }
	class SpecificClass : AbstractGeneralClass<ClassB> { }
