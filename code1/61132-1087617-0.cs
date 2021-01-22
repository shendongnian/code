    [Test]
    public void ProjectMatrix_Injection_IsLoaded()
        {
            _projectMatrix = MockRepository.GenerateMock<ITimeSheetMatrixWidget>();
            var dtos = _facade.ProjectDtos;
            _projectMatrix.Expect(x => x.Load(Arg<IEnumerable<DynamicDisplayDto>>.List.Equal(dtos))).Return(dtos.Count());
            new MatrixEntryService(_facade, _projectMatrix, _nonProjectMatrix, _totalMatrix);
            _projectMatrix.VerifyAllExpectations();
        }
