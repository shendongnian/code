string s;
using (WebClient wc = new WebClient())
{
  wc.QueryString.Add ("Param1", "param1value");  
  wc.QueryString.Add ("Param2", "param2value");           
  s = wc.DownloadString (webaddress);
}
