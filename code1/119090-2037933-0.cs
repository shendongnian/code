    public class Post
    {
    
        public string Subject { get; set; }
    
        public string ResolveSubjectForUrl()
        {
            return Regex.Replace(Regex.Replace(this.Subject.ToLower(), "[^\\w]", "-"), "[-]{2,}", "-");
        }
    
    }
