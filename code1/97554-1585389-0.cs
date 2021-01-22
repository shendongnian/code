    [TestMethod]
    public void HomeController_Index_Action_Should_Accept_Post_Verb_Only()
    {
        Expression<Action<HomeController>> expression = (HomeController c) => c.Index(null);
        var methodCall = expression.Body as MethodCallExpression;
        var acceptVerbs = (AcceptVerbsAttribute[])methodCall.Method.GetCustomAttributes(typeof(AcceptVerbsAttribute), false);
        acceptVerbs.ShouldNotBeNull("");
        acceptVerbs.Length.ShouldBe(1);
        acceptVerbs[0].Verbs.First().ShouldBe("POST");
    }
