    [Test]
    public void View_OnGetContentXmlButtonClick_When_FileDoesNotExist_Should_RelayMessage()
    {
        //SETUP
        XmlDocument xmlDocument = new XmlDocument();
        using (Mockery.Record())
        {
            SetupResult.For(_view.FilePath).Return("C:\Test.txt");
            Expect.Call(_bc.GetContentXml("C:\Test.txt")).Return(null);
            _view.Xml = xmlDocument.InnerXml;
            _view.Message = MESSAGE_FILE_NOT_EXIST;
        }
    
        //EXECUTE
        using (Mockery.Playback())
        {
            _presenter.View_OnGetContentXmlButtonClick();
            _raiser.Raise(_bc, new MessageEventArgs(MESSAGE_FILE_NOT_EXIST));
        }
    }
