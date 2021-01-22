     private bool CaseInsensitive( string s, string t )
     {
          return string.Equals( s, t, StringComparison.OrdinalIgnoreCase );
     }
     var loggerMock = MockRepository.GenerateMock<Logger>();
     loggerMock.Expect( l => l.LogMessage( Arg<string>.Matches( s => CaseInsensitive( s, "f2" ))));
     classUnderTest.MethodUnderTest();
     loggerMock.VerifyAllExpectations();
