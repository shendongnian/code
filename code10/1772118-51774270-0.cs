            var objectValidator = new Mock<IObjectModelValidator>();
            objectValidator.Setup(o => o.Validate(It.IsAny<ActionContext>(), 
                                              It.IsAny<ValidationStateDictionary>(), 
                                              It.IsAny<string>(), 
                                              It.IsAny<Object>()));
            controller.ObjectValidator = objectValidator.Object;
