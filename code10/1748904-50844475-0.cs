        [TestMethod]
        public void ValiderAttribut_EstResponsable()
        {
            var attribut = new ResponsableAttribute(); // Instantiation of the attribute
            var controller = ObtenirController(); // Gets the controller via MvcFakes
            SecuriteHelper.VerifierResponsable().Returns(true); // Sets the desired return value
            var test = Substitute.For<ActionExecutingContext>(); // Substitute for ActionExecutingContext
            test.Controller = controller; // Sets the controller to the context
            attribut.OnActionExecuting(test); // Call the overrided method
            Assert.IsNull(test.Result); // Check if the redirection occured
        }
