    [TestMethod]
    public void Should_update_foo_to_active_inside_of_repository()
    {
        // arrange
        var repo = MockRepository.GenerateMock<IRepository>();
        var foo = new Foo() { ID = 1, IsActive = false };
        var target = new Presenter(repo);
        repo.Expect(x => x.ActivateFoo(foo)).
            Do(new Func<Foo, bool>(
                delegate(Foo f) { f.IsActive = true; return true; }
            ));
        // act
        target.Activate(foo);
        // assert
        Assert.IsTrue(foo.IsActive);
        repo.VerifyAllExpectations();
    }
