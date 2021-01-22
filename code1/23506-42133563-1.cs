    [TestMethod]
    public void ShouldThrottleReading()
    {
        var content = Enumerable
            .Range(0, 1024 * 1024)
            .Select(_ => (byte)'a')
            .ToArray();
        var scheduler = new TestScheduler();
        var source = new ThrottledStream(new MemoryStream(content), content.Length / 8, scheduler);
        var target = new MemoryStream();
        var t = source.CopyToAsync(target);
        t.Wait(10).Should().BeFalse();
        scheduler.AdvanceTo(TimeSpan.FromSeconds(4).Ticks);
        t.Wait(10).Should().BeFalse();
        scheduler.AdvanceTo(TimeSpan.FromSeconds(8).Ticks - 1);
        t.Wait(10).Should().BeFalse();
        scheduler.AdvanceTo(TimeSpan.FromSeconds(8).Ticks);
        t.Wait(10).Should().BeTrue();
    }
    [TestMethod]
    public void ShouldThrottleWriting()
    {
        var content = Enumerable
            .Range(0, 1024 * 1024)
            .Select(_ => (byte)'a')
            .ToArray();
        var scheduler = new TestScheduler();
        var source = new MemoryStream(content);
        var target = new ThrottledStream(new MemoryStream(), content.Length / 8, scheduler);
        var t = source.CopyToAsync(target);
        t.Wait(10).Should().BeFalse();
        scheduler.AdvanceTo(TimeSpan.FromSeconds(4).Ticks);
        t.Wait(10).Should().BeFalse();
        scheduler.AdvanceTo(TimeSpan.FromSeconds(8).Ticks - 1);
        t.Wait(10).Should().BeFalse();
        scheduler.AdvanceTo(TimeSpan.FromSeconds(8).Ticks);
        t.Wait(10).Should().BeTrue();
    }
