    public abstract class Cheese { }
    
    public class BlueCheese : Cheese { }
    
    public abstract class CheeseTool<T> where T:Cheese { }
    
    public class BlueCheeseTool : CheeseTool<BlueCheese> { }
    
    public class CheeseEater<T> where T : Cheese {
        public T Cheese;
        public CheeseTool<T> Tool;
    }
