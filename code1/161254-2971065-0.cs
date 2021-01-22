    class Driver
    {
        private ICar car = GetCarFromGarage();
    
        public void FloorIt()
        {
            if (this.car is Bmw)
            {
                ((Bmw)this.car).AccelerateReallyFast();
            }
            else if (this.car is Toyota)
            {
                ((Toyota)this.car).StickAccelerator();
            }
            else
            {
                this.car.Go();
            }
        }
    }
