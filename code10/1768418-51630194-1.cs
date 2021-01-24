    public class MyActivityLogger : IActivityLogger
    {
        public async Task LogAsync(IActivity activity)
        {
            if (activity.From.Name!= "{your_botid_here}")
            {
                var uid = activity.From.Id;
                var uname = activity.From.Name;
    
                var userinput = (activity as IMessageActivity).Text?.ToString();
    
                //extract other data from "activity" properties
    
                //your code logic here
                //store data in your table storage
    
                //Note: specifcial scenario of user send attachment
    
            }
        }
    }
