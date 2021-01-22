        public sealed class SealedClass
    	{
    		public void DoSmth()
    		{ }
    	}
    
    	public class ClassWithSealedMethod : ClassWithVirtualMethod
    	{
    		public sealed override void DoSmth()
    		{ }
    	}
    
    	public class ClassWithVirtualMethod
    	{
    		public virtual void DoSmth()
    		{ }
    	}
