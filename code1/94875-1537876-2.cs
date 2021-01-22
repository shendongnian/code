    public class TestFixture{
    
    
    private ISharedSpaceGateway gateway;
    [TestInitialize()]
     public void MyTestInitialize() 
     {
        gateway = MockRepository.CreateMock<ISharedSpaceGateway>();
        gateway.Expect(g => g.GetSharedSpaces("spaceName", "user1@domain.com"))
              .Return(new SharedSpace()); // whatever you want to return from the fake call
    
             user = new User()
             {
                     Active = true,
                     Name = "Main User",
                     UserID = 1,
                     EmailAddress = "user1@userdomain.com",
                     OpenID = Guid.NewGuid().ToString()
             };
    
             account = new Account(gateway) // inject the fake object
             {
                     Key1 = "test1",
                     Key2 = "test2",
                     AccountName = "Brief Account Description",
                     ID = 1,
                     Owner = user
             };
     }
    [TestMethod]
    public void Cannot_Share_SameSpace_with_same_userEmail_Twice()
    {
            account.ShareSpace("spaceName", "user1@domain.com");
            try
            {
              account.ShareSpace("spaceName", "user1@domain.com");
              Assert.Fail("Should throw exception when same space is shared with same user.");
            }
            catch (InvalidOperationException)
            { /* Expected */ }
            Assert.AreEqual(1, account.MySpacesShared.Count);
            Assert.AreSame(null, account.MySpacesShared.First().InvitedUser);
            gateway.VerifyAllExpectations();
    }
