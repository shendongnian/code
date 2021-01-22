    class Vehicle
    {
        public virtual bool LicenceRequired
        {
            get{throw new NotImplmentedException()
        }
    }
    class Bicycle
    {
        public override bool LicenceRequired
        {
            get{return false;}
        }
    }
    class Car
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
    class TestBicycle
    {
        public override void LicenceRequiredTest()
        {
            Assert.IsFalse(LicenceRequired);
        }
    }
    class TestCar
    {
        public override void LicenceRequiredTest()
        {
            Assert.IsTrue(LicenceRequired);
        }
    }
