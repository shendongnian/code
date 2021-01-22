    [Test]
    [ExpectedException (typeof (NotSupportedException))]
    public void Test_ProcessTransmissionStatus_ExtendedEnum ()
    {
        MyClass myClass = new MyClass ();
        myClass.ProcessTransmissionStatus ((TransmissionStatus)(10));
    }
