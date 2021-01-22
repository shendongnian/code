    public class Vehicle {
        public virtual void Go() {
              Log(this.GetType().Name);
        }
    }
    public class Car : Vehicle {
        public override void Go() {
             base.Go();
             // Do car specific stuff
        }
    }
    public class Bus : Vehicle {
    }
