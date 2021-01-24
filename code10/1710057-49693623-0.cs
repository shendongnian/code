    public class TokenRequest
        {
            public PostMe PostMe { get; set; }
    
            public TokenRequest()
            {
                PostMe = new PostMe()
                {
                    Name = "ABC ABC",
                    ManagementId = "ABC ABC",
                    ProxyUrl = ABC,
                    SourceFilename = ABC,
                }; ;
            }
    
            public TokenRequest(PostMe postMe)
            {
                PostMe = postMe;
            }
    
            public static string TokenGenerate()
            {
                var client = new RestClient("any url ");
                var request = new RestRequest(Method.POST);
    
                //  I want change the value of this PostMe properties for few test cases. since it's a executed under"BaseTest" and called before any test so I am not sure how to change these properties "Name, ProxyUrl etc" according to test. 
    
                var postMe = PostMe;
            }
        }
