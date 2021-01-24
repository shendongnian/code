	//Arrange
	//...initialize controller and its dependencies
	//add model error to force IsValid to be false.
	controller.ModelState.AddModelError("PropertyName", "Error Message");
	var alias = string.Empty;
	var expectedErrorMessage = "COMMON_ERROR";
	//Act
	Action act = () => controller.DeleteModelAliasData(alias);
	//Assert
	Assert.That(act, Throws.TypeOf<BusinessException>()
					 .With.Message.EqualTo(expectedErrorMessage));
