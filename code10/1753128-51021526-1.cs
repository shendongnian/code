    class MyMock : MyObject
    {
        override void SomeMethodWhichIsCalled()
        {
            throw new Exception("Method was called");
        }
    }
