    [Test]
    public void Accesses_Name_Of_Current_Principal_When_Setting_ModifiedBy() {
        Mock<IPrincipal> mockPrincipal = new Mock<IPrincipal>();
        Mock<IAuditable> mockAuditable = new Mock<IAuditable>();
        mockPrincipal.SetupGet(p => p.Identity.Name).Returns("test");
        Thread.CurrentPrincipal = mockPrincipal.Object;
        AuditManager.SetAuditProperties(mockAuditable.Object);
        mockPrincipal.VerifyGet(p => p.Identity.Name);
        mockAuditable.VerifySet(a => a.ModifiedBy = "test");
    }
