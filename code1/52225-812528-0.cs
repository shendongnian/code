    message = Collection.CreateNewMessage("FileDownlading");
    DateTime dtStart = DateTime.Now;
    WebClass.DownloadAFile("You Know This File Is Great.XML");
    DateTime dtEnd = DateTime.Now;
    // perform comparison here to see how long it took.
    // dispose of DateTimes
    dtStart = dtEnd = null;
