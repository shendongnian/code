    interface IVehicle
    {
      void Move();
      void Stop();
    }
    
    class Toy{}
    
    class PogoStick : Toy, IVehicle
    {
      public void Move(){ /* boing boing */}
      public void Stop(){ /* fall over */}
    }
    
    class Car: IVehicle
    {
      public void Move(){ /* vroom vroom */}
      public void Stop(){ /* <screeeech!> */}
    }
    
    class Person : IVehicle
    {
      public string Name{get;set;}
      public void Walk() {/*code elided*/}
      void IVehicle.Move() { Walk(); }
      void IVehicle.Stop() { /*whatever!*/}
    }
    
    class Program
    {
      static void Main()
      {
        IVehicle[] vehicles = new IVehicle[3];
        vehicles[0] = new PogoStick();
        vehicles[1] = new Car();
        vehicles[2] = new Employee(); //implements IVehicle because it IS A KIND OF Person
    
        vehicles.ForEach(v => v.Move());
    
        //it's worth pointing out that
        vehicles[2].Stop();
        //works fine, but
        Person p = new Person();
        p.Move();
        //won't, as I explicitly implemented the interface, meaning I can only get at the
        //methods via a reference to the interface, not to the implementing class.
      }
    }
