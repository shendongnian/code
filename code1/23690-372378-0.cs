    try
    {
       Operation1();
    }
    catch (MySpecificException1)
    {
       RecoverFromExpectedException1();
    }
    try
    {
      Operation2();
    }
    catch (MySpecificException2)
    {
       RecoverFromExpectedException2();
    }
