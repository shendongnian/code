    public RemoteViews GetViewAt(int position)
    {
        var rV = new RemoteViews(_context.PackageName, 
                   Resource.Layout.Widget_EpisodeItem); //The list row layout
        var data = _episodes[position];
        rV.SetTextViewText(Resource.Id.Home_IncomingItem_Title, "titre");
     
        var ei = "2x04 : Nous à infinite square";
        rV.SetTextViewText(Resource.Id.Home_IncomingItem_EpisodeTitle, ei);
     
        return remoteView;
    }
