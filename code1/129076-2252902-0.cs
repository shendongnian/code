        public class PostCompareManager
            {
                public void main()
                {
                    // may use url(string) of the post as ID or replace 
                    // it with something unique, representing each post
                    Dictionary<string, Post> revPost = new Dictionary<string,Post>(); // replace with you HTTP get logic
                    Dictionary<string, Post> newPost = new Dictionary<string, Post>(); // replace with you HTTP get logic
        
                    var oldKeys = revPost.Keys;
                    foreach (var k in newPost.Keys)
                    {
                        oldKeys.Contains(k);
                        //do something
                    }
                }
            }
            class Post
            {
                string title; string description; string url;
            }
