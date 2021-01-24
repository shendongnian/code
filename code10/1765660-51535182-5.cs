        public abstract class Fruit
        {
            public abstract int MyOrder {get;}
        }
        
        public class Apple : Fruit
        {    
            public override int MyOrder {
                get { return 1;}
            }
        }
        
        public class Orange : Fruit
        {  
            public override int MyOrder {
                get { return 2;}
            }  
        }
