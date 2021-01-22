    [Test]
    public void NonProjectMatrix_Injection_IsLoaded()
    {
        _nonProjectMatrix = MockRepository.GenerateMock<ITimeSheetMatrixWidget>();
        var dtos = _facade.NonProjectDtos;
        nonProjectMatrix.Expect(x => x.Load(Arg<IEnumerable<DynamicDisplayDto>>.List.Equal(dtos))).Return(dtos.Count());
            new MatrixEntryService(_facade, _projectMatrix, _nonProjectMatrix, _totalMatrix);
            _nonProjectMatrix.VerifyAllExpectations();
        }
