    NSUrlSession session = NSUrlSession.SharedSession;
    var dataTask = session.CreateDataTask(new NSUrlRequest(new NSUrl("yourUrl")), (data, response, error) =>
    {
        if (response != null)
        {
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                MyImageView.Image = UIImage.LoadFromData(data);
            });
        }
    });
    
    dataTask.Resume();
