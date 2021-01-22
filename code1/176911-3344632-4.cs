    public abstract class Animal {
        protected Animal(int legs) {
            this.legs = legs;
        }
    }
    public class Dog: Animal {     
        public Dog(): base(4) {}
    }
