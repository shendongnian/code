        [TestMethod]
        public void ValiderAttribut_EstNonResponsable()
        {
            var attribut = new ResponsableAttribute();
            var controller = ObtenirController();
            SecuriteHelper.VerifierResponsable().Returns(false);
            var test = Substitute.For<ActionExecutingContext>();
            test.Controller = controller;
            attribut.OnActionExecuting(test);
            Assert.IsNotNull(test.Result);
            Assert.AreEqual(typeof(RedirectResult), test.Result.GetType());
        }
