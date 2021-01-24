        // ...
        using Microsoft.AspNetCore.Mvc;
        [TestMethod]
        public async Task Group_Get_Should_Return_InstanceOfTypeOkNegotiatedContentResultIEnumerableGroupDto()
        {
        	// Arrange
    	    moqGroupRepository.Setup(g => g.GetAllAsync(null)).ReturnsAsync(groups).Verifiable();
        	moqUnitOfWork.Setup(x => x.Repository<Groupe>()).Returns(moqGroupRepository.Object);
    
        	var controller = new GroupController(moqUnitOfWork.Object);
    
    	    // Act
        	var actionResult = await controller.Get() as OkObjectResult;
    
        	// Assert
    	    Assert.IsNotNull(actionResult);
        	Assert.IsInstanceOfType(actionResult.Value, typeof(IEnumerable<GroupDto>));
        }
