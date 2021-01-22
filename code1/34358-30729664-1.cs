    class Vehicle
    {
        public virtual bool LicenceRequired
        {
            get{throw new NotImplmentedException()
        }
    }
    class Bicycle:Vehicle
    {
        public override bool LicenceRequired
        {
            get{return false;}
        }
    }
    class Car:Vehicle
    {
        public override bool LicenceRequired
        {
            get{return true;}
        }
    }
    class TestVehicle
    {
        public virtual Void LicenceRequiredTest()
        {
            Try
            {
                LicenceRequired
                Assert.Fail();
            }
            Catch(){}
        }
    }
    class TestBicycle:TestVehicle
    {
        public override void LicenceRequiredTest()
        {
            Assert.IsFalse(LicenceRequired);
        }
    }
    class TestCar:TestVehicle
    {
        public override void LicenceRequiredTest()
        {
            Assert.IsTrue(LicenceRequired);
        }
    }
