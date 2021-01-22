    // arrange
    IList<Record> testdata = new List<Record>() {a, b, c};
    db = MockRepository.GenerateMock<IDatabase>();
    db.Stub(x => db.getTable).Return(testdata);
    
    // act: call your unit under test
    
    // assert
    db.AssertWasCalled(x => x.InsertOnSubmit(Arg<Record>.Is.Anything));
    db.AssertWasCalled(x => x.SubmitChanges());
