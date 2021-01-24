`
// First time says "logged out"
Dictionary<string, string> data = new Dictionary<string, string>();
data.Add("utf8", WebUtility.UrlEncode("✓"));
string token = GetToken();
string tokenEncoded = WebUtility.UrlEncode(token);
data.Add("authenticity_token", tokenEncoded);
data.Add("plan", "");
data.Add("email", "youremail");
data.Add("password", "yourpwd");
data.Add("remember_me", "on");
string parameters = PostParam(data);
hc.PostData(sessionURL, parameters, loginURL);
// Second time logs in
Dictionary<string, string> data = new Dictionary<string, string>();
data.Add("utf8", WebUtility.UrlEncode("✓"));
string token = GetToken();
string tokenEncoded = WebUtility.UrlEncode(token);
data.Add("authenticity_token", tokenEncoded);
data.Add("plan", "");
data.Add("email", "youremail");
data.Add("password", "yourpwd");
data.Add("remember_me", "on");
string parameters = PostParam(data);
hc.PostData(sessionURL, parameters, loginURL);
`
Note: 
`
// Keep this on default value "true"
//WebRequest.AllowAutoRedirect = false;
`
