    public async Task ShouldRedirect()
    {
        var controller = new Controller();
        var result = await controller.Create(item);
        result.Should().BeOfType<RedirectResult>();
    }
