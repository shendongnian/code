    void VerifyMany(int input)
    {
        _myClassMock.Verify(ic => ic.DoStuffA(input), Times.Once());
        _myClassMock.Verify(ic => ic.DoStuffB(input), Times.Once());
    }
