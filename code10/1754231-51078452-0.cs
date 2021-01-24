    public async Task LogAsync(IActivity activity)
    {
        if (activity.From.Name== "fehanbasicbot")
        {
            activity.From.Name = "testbot";
        }
    }
