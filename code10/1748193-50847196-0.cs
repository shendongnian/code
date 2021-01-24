    public class Logger : IActivityLogger
    {
        public async Task LogAsync(IActivity activity)
        {
            IMessageActivity a = activity.AsMessageActivity();
            //loop through for cases there are multiple attachments
            for (int i = 0; i < a.Attachments.Count; i++)
            {
                //in the case of herocard
                if (a.Attachments[i].ContentType == "application/vnd.microsoft.card.hero")
                {
                    //log something, i randomly picked a property
                    Debug.WriteLine(a.Attachments[i].Name);
                }
                //another case
                if (a.Attachments[i].ContentType.Contains("image"))
                {
                    //Maybe save the image somewhere
                }
            }
            Debug.WriteLine(activity.AsMessageActivity()?.Text);
        }
    }
