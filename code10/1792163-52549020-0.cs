    CloudAppendBlob appendBlob = container.GetAppendBlobReference("myAppendBlob");
    appendBlob.FetchAttributes();
    var etag = appendBlob.Properties.ETag;
    try
    {
        appendBlob.DownloadToStream(ms, AccessCondition.GenerateIfMatchCondition(etag));
    }
    catch (Exception)
    {
        appendBlob.FetchAttributes();
        var updateEtag = appendBlob.Properties.ETag;
        Console.WriteLine($"Original:{etag},Updated:{updateEtag}");
        //To Do list
        //appendBlob.DownloadToStream(ms, AccessCondition.GenerateIfMatchCondition(updateEtag));
    }
