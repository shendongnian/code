    [Extension("Converts ASCII smilies into real smilies in the comments", "1.3", "BlogEngine.NET")]
    public class Smilies
    {
    
        static Smilies()
        {
            Comment.Serving += new EventHandler<ServingEventArgs>(Post_CommentServing);
        }
    
        private const string LINK = "<img src=\"{0}editors/tiny_mce3/plugins/emotions/img/smiley-{1}.gif\" class=\"flag\" alt=\"{2}\" />";
    
        /// <summary>
        /// The event handler that is triggered every time a comment is served to a client.
        /// </summary>
        private static void Post_CommentServing(object sender, ServingEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Body))
            {
                e.Body = e.Body.Replace("(H)", Convert("cool", "Cool"));
                e.Body = e.Body.Replace(":'(", Convert("cry", "Cry"));
                e.Body = e.Body.Replace(":$", Convert("embarassed", "Embarassed"));
                e.Body = e.Body.Replace(":|", Convert("foot-in-mouth", "Foot"));
                e.Body = e.Body.Replace(":(", Convert("frown", "Frown"));
                e.Body = e.Body.Replace("(A)", Convert("innocent", "Innocent"));
                e.Body = e.Body.Replace("(K)", Convert("kiss", "Kiss"));
                e.Body = e.Body.Replace(":D", Convert("laughing", "Laughing"));
                e.Body = e.Body.Replace("($)", Convert("money-mouth", "Money"));
                e.Body = e.Body.Replace(":-#", Convert("sealed", "Sealed"));
                e.Body = e.Body.Replace(":)", Convert("smile", "Smile"));
                e.Body = e.Body.Replace(":-)", Convert("smile", "Smile"));
                e.Body = e.Body.Replace(":-O", Convert("surprised", "Surprised"));
                e.Body = e.Body.Replace(":P", Convert("tongue-out", "Tong"));
                e.Body = e.Body.Replace("*-)", Convert("undecided", "Undecided"));
                e.Body = e.Body.Replace(";-)", Convert("wink", "Wink"));
                e.Body = e.Body.Replace("8o|", Convert("yell", "Yell"));
            }
        }
    
        /// <summary>
        /// Formats the anchor and inserts the right smiley image.
        /// </summary>
        private static string Convert(string name, string alt)
        {
            return string.Format(LINK, Utils.RelativeWebRoot, name, alt);
        }
    }
