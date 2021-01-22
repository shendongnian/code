    [Test]
    public void Download_attaches_events_when_created()
    {
        // Arrange
        var download = MockRepository.GenerateMock<Download>();
        // Act
        var downloadEntity = new DownloadEntity(download);
        // Assert
        download.AssertWasCalled(x => x.DownloadProgress_Changed += Arg<EventHandler<DownloadProgressEventArgs>>.Is.Anything);
    }
