    // setup mock to return the emptyDataSet for any argument    
    SetupResult.For(dalMock.GetDataSet(Arg<int>.Is.Anything))
      .Do((GetDataSetDelegate)delegate(int i)
        {
          Assert.AreEqual(7, i);
        }
      .Return(emptyDataSet)
      .Repeat.Any();
    sut.Execute()
    
