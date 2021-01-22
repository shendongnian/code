    [TestMethod]
    public void SaveResponsibleUserFromChangeset()
    {
        var action = mocks.StrictMock<GenomeAction>();
        var changeset = new ActionChangeset();
        var identityResolver;
        changeset.ResponsibleUser = new ChangeableProperty<UserIdentity>("Administrator") {IsChanged = true};
        changeset.MarkAll(true);
        using(mocks.Record())
        {
            Expect.Call(action.ResponsibleUser).SetPropertyAndIgnoreArgument();
            identityResolver = new MockIdentityResolver()
        }
        using(mocks.Playback())
        {
            var persistor = new ActionPersistor(identityResolver);
            persistor.SaveActionChanges(changeset, action);
        }
        action.VerifyAllExpectations();
    }
    private class MockIdentityResolver : IIdentityResolver
    {
        public GenomeUser GetUser(UserIdentity identity)
        {
            var user = mocks.DynamicMock<GenomeUser>();
            user.Username = identity.Username;
            return user;
        }
    }
