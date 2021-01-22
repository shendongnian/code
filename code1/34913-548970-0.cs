Users users = null;
if (Timeline != null)
{
    TwitterooCore core = new TwitterooCore(username, password);
    if (core != null)
    {
        var friends = Timeline.Friends
        if (friends != null)
            users = core.GetTimeline(Timeline.Friends);
    }
}
