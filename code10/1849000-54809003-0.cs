    [Theory(DisplayName = "Definition Types service - Create")]
    [MemberData(nameof(DefinitionTypesTestData.SingleDefinitionType), MemberType = typeof(DefinitionTypesTestData))]
    public async Task CreateDefinitionTypeShouldThrowDuplicateTest(DefinitionType obj) {
        
        if (obj == null) throw new NullReferenceException($"Test data was null in theory 'Definition Types service - Create'");
        
        //Arrange
        var crudService = new Mock<IEntityCrudService<DefinitionType>>();
        
        var list = new List<DefinitionType>() {
            new DefinitionType {
                Name = "Test",
                Description = "Test",
                DisplayName = "Test",
                ID = Guid.NewGuid()
            }
        };
        
        crudService
            .Setup(_ => _.GetEntitiesAsync(It.Is<Expression<Func<DefinitionType, bool>>>(exp => exp.Compile()(obj))))
            .ReturnsAsync(list);
            
        IDefinitionTypesService serviceUnderTest = new DefinitionTypesService(crudService.Object);
        
        //Act
        var exception = await Assert.ThrowsAsync<EntityDuplicationException>(() => serviceUnderTest.InsertDefinitionTypeAsync(obj));
        
        //Assert
        Assert.Contains("Definition type", exception.DisplayMessage);
        Assert.Contains(obj.Name, exception.DisplayMessage);
        crudService.Verify(_ => _.GetEntitiesAsync(It.Is<Expression<Func<DefinitionType, bool>>>(exp => exp.Compile()(obj))), Times.Once);
        crudService.VerifyNoOtherCalls();
    }
