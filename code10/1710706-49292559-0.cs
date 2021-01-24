    [Test]
    public void TestDeleteModelAliasData()
    {
        // Get your controller instance - you know it better how to instantiate
        var controller = GetControllerInstance();
        // Add error message to ModelState
        controller.ModelState.AddModelError("PropertyName", "Error Message");
        var alias = "sampleAlias";
        // As ModelState is having an Error, the method should throw BusinessException
        var ex = Assert.Throws<BusinessException>(() => controller.DeleteModelAliasData(alias));
        // Exception is raised, assert the message if you want
        Assert.That(ex.Message, Is.EqualTo("COMMON_ERROR"));
    }
