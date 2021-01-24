    emailMock.Setup(x => x.CreateMailItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())
        .CallBack<string, string, string>(this.TestCreateMailItem));
    email = emailMock.Object;
    private void TestCreateMailItem(string to, string from, string address)
    {
        emailMock.Object.CreateMailItem("test@test.com", from, address);
    }
