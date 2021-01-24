    public class Car : Vehicle
    {
        public sealed override void Start()
        {
            // Todo => codes that every car must invoke before start ...
            CarStart();
            // Todo => codes that every car must invoke after start ...
        }
        public virtual void CarStart() { }
    }
