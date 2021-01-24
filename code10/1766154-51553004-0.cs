    public class Car : Vehicle
    {
         sealed protected override void Start()
        {
            // Todo => codes that every car must invoke before start ...
            CarStart();
            // Todo => codes that every car must invoke after start ...
        }
    
        public virtual void CarStart() { }
    }
