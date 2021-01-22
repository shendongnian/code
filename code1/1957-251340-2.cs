    interface IVehicle
    {
        void Drive();
        void Steer();
        void UseHook();
    }
    abstract class Vehicle  // :IVehicle  // Try it and see!
    {
        /// <summary>
        /// Consuming classes are not required to implement this method.
        /// </summary>
        protected virtual void Hook()
        {
            return;
        }
    }
    class Car : Vehicle, IVehicle
    {
        protected override void Hook()  // you must use keyword "override"
        {
            Console.WriteLine(" Car.Hook(): Uses abstracted method.");
        }
        #region IVehicle Members
        public void Drive()
        {
            Console.WriteLine(" Car.Drive(): Uses a tires and a motor.");
        }
        public void Steer()
        {
            Console.WriteLine(" Car.Steer(): Uses a steering wheel.");
        }
        /// <summary>
        /// This code is duplicated in implementing classes.  Hmm.
        /// </summary>
        void IVehicle.UseHook()
        {
            this.Hook();
        }
        #endregion
    }
    class Airplane : Vehicle, IVehicle
    {
        protected override void Hook()  // you must use keyword "override"
        {
            Console.WriteLine(" Airplane.Hook(): Uses abstracted method.");
        }
        #region IVehicle Members
        public void Drive()
        {
            Console.WriteLine(" Airplane.Drive(): Uses wings and a motor.");
        }
        public void Steer()
        {
            Console.WriteLine(" Airplane.Steer(): Uses a control stick.");
        }
        /// <summary>
        /// This code is duplicated in implementing classes.  Hmm.
        /// </summary>
        void IVehicle.UseHook()
        {
            this.Hook();
        }
        #endregion
    }
