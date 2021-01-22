// encode form data
StringBuilder postString = new StringBuilder();
bool first=true;
foreach (KeyValuePair<string, string> pair in _formValues)
{
	if(first)
		first=false;
	else
		postString.Append("&");
	postString.AppendFormat("{0}={1}", pair.Key, System.Web.HttpUtility.UrlEncode(pair.Value));
}
ASCIIEncoding ascii = new ASCIIEncoding();
byte[] postBytes = ascii.GetBytes(postString.ToString());
// set up request object
HttpWebRequest request;
try
{
	request = WebRequest.Create(url) as HttpWebRequest;
}
catch (UriFormatException)
{
	request = null;
}
if (request == null)
	throw new ApplicationException("Invalid URL: " + url);
request.Method = "POST";
request.ContentType = "application/x-www-form-urlencoded";
request.ContentLength = postBytes.Length;
// add post data to request
Stream postStream = request.GetRequestStream();
postStream.Write(postBytes, 0, postBytes.Length);
postStream.Close();
HttpWebResponse response = request.GetResponse as HttpWebResponse;
