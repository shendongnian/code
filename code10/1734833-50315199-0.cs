    // Act
    IHttpActionResult actionResult = controller.Post(It.IsAny<StudentModel>());
    var createdResult = actionResult as NegotiatedContentResult<Student>;
    //Assert
    Assert.IsNotNull(actionResult);
    Assert.IsNotNull(createdResult.Content);
    Assert.AreEqual(1, createdResult.Content.Id);
    Asssert.AreEqual(HttpStatusCode.Created, createdResult.StatusCode); // <-- check status
