       abstract class A {
        public interface IA{
    
        }
    
        abstract protected void Print(IA obj);
    }
    
    abstract class B : A {
        public interface IB : IA{
    
        }
    
    	override protected void Print(IA obj){
    	}
    	
        protected void Print(IB obj){
          Print(obj as IA);
        }
    }
