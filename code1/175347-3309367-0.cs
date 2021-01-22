    [Test]
    public void DirctoryResult_Returns_Groups()
    {
        var service = autoMocker.Get<IGroupService>();
        service.Expect(srv => srv.GetGroupsByQuery(Arg<string>.Is.Anything))
            .Return(new List<CompanyGroupInfo>
                        {
                            new CompanyGroupInfo(),
                            new CompanyGroupInfo(),
                            new CompanyGroupInfo()
                        });
        service.Replay();
        var directoryResult = _controller.DirectoryResult("b");
        var fundDirectoryViewModel = (FundDirectoryViewModel)directoryResult.ViewData.Model;
        Assert.That(fundDirectoryViewModel.Groups.Count, Is.EqualTo(3));
        service.AssertWasCalled(srv => srv.GetGroupsByQuery(Arg<string>.Is.Equal("b")));
    }
