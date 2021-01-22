    [Test]
    public void Accesses_Name_Of_Current_Principal_When_Setting_ModifiedBy() {
        Mock<IPrincipal> mockPrincipal = new Mock<IPrincipal>();
        Mock<IAuditable> mockAuditable = new Mock<IAuditable>();
        mockPrincipal.SetupGet(p => p.Identity.Name).Returns("test");
        var auditable = mockAuditable.Object;
        Thread.CurrentPrincipal = mockPrincipal.Object;
        AuditManager.SetAuditProperties(auditable);
        Assert.AreEqual("test", auditable.ModifiedBy);
    }
