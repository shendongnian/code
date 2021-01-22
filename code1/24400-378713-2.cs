    abstract class Body
    {
       abstract void Collision(Body other);
    }
    
    class Dog : Body
    {
       public override void Collision(Body other) {
          this.Bark();
       }
    
       public void Bark() { ... }
    }
