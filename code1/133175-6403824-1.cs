    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Data;
    using System.Threading;
    namespace UpdateListserv
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    File.Delete(_logFilename);
                    Log(String.Format("Starting: {0}", DateTime.Now));
                    Login();
                    var roster = GetSubscribers();
                    Unsubscribe(roster);
                    string members = GetMemberEmails();
                    Subscribe(members); 
                    Unmoderate("foo@example.com");
                    Log("Done");
                }
                catch(Exception e)
                {
                    Log(e.Message);
                }
            }
            private static void Unmoderate(string email)
            {                
                Log("Unmoderating " + email);
                email = email.Replace("@", "%40");
                _vars.Clear();
                _vars["user"] = email;
                _vars[email + "_nomail"] = "off";
                _vars[email + "_nodupes"] = "on";
                _vars[email + "_plain"] = "on";
                _vars[email + "_language"] = "en";
                _vars["setmemberopts_btn"] = "Submit Your Changes";
                FormUpload.MultipartFormDataPost(_adminUrl + _membersPage, "foobar", _vars, _cookies);
            }
            private static CookieContainer _cookies = new CookieContainer();
            private static string _adminUrl = "http://mylist.com/admin.cgi/listname";
            private static string _rosterUrl = "http://mylist.com/roster.cgi/listname";
            private static string _pw = "myPassword";
            private static string _adminEmail = "foo@example.com";
            private static Dictionary<string, object> _vars = new Dictionary<string, object>();
            private static string _addPage = "/members/add";
            private static string _removePage = "/members/remove";
            private static string _membersPage = "/members";
            private static string _logFilename = "Update Listserv.log";
            private static void Log(string message)
            {
                Console.WriteLine(message);
                using (var log = File.AppendText(_logFilename))
                    log.WriteLine(message);
            }
            private static void Subscribe(string members)
            {
                // members is a list of email addresses separated by \n
                Log("Subscribing everyone");
                _vars.Clear();
                _vars["subscribees"] = members;
                _vars["subscribe_or_invite"] = 0;
                _vars["send_welcome_msg_to_this_batch"] = 0;
                _vars["send_notifications_to_list_owner"] = 0;
                FormUpload.MultipartFormDataPost(_adminUrl + _addPage, "foobar", _vars, _cookies);
            }
            private static string GetMemberEmails()
            {
                // This method retrieves a list of emails to be 
                // subscribed from an external source
                // and returns them as a string with \n in between.
            }
            private static void Unsubscribe(string roster)
            {
                // roster is a list of email addresses separated by \n
                Log("Unsubscribing everybody");
                _vars.Clear();
                _vars["unsubscribees"] = roster;
                _vars["send_unsub_ack_to_this_batch"] = 0;
                _vars["send_unsub_notifications_to_list_owner"] = 0;
                FormUpload.MultipartFormDataPost(_adminUrl + _removePage, "foobar", _vars, _cookies);
            }
            private static string GetSubscribers()
            {
                // returns a list of email addresses subscribed to the list,
                // separated by \n
                Log("Getting subscriber list");
                var req = GetWebRequest(_rosterUrl);
                req.Method = "post";
                _vars.Clear();
                _vars["roster-email"] = _adminEmail;
                _vars["roster-pw"] = _pw;
                var rosterLines = GetResponseString(req).Split('\n').Where(l => l.StartsWith("<li>"));
                Log(String.Format("Got {0} subscribers", rosterLines.Count()));
                var roster = new List<string>();
                var regex = new Regex("<a.*>(.*)</a>");
                foreach (var line in rosterLines)
                {
                    roster.Add(regex.Match(line).Groups[1].Value.Replace(" at ", "@"));
                }
                return String.Join("\n", roster);
            }
            private static void Login()
            {
                Log("Logging in to list admin panel");
                var req = GetWebRequest(_adminUrl);
                req.Method = "post";
                _vars["adminpw"] = _pw;
                SetPostVars(req);
                req.GetResponse();
            }
            private static HttpWebRequest GetWebRequest(string url)
            {
                var result = HttpWebRequest.Create(url) as HttpWebRequest;
                result.AllowAutoRedirect = true;
                result.CookieContainer = _cookies;
                result.ContentType = "application/x-www-form-urlencoded";
                return result;
            }
            private static string GetResponseString(HttpWebRequest req)
            {
                using (var res = req.GetResponse())
                using (var stream = res.GetResponseStream())
                using (var sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }
            private static void SetPostVars(HttpWebRequest req)
            {
                var list = _vars.Select(v => String.Format("{0}={1}", v.Key, v.Value));
                using (var stream = req.GetRequestStream())
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(String.Join("&", list));
                }
            }
        }
    }
