    using Google.Contacts;
    using Google.GData.Client;
    using Google.GData.Contacts;
    using Google.GData.Extensions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                GetAccessToken();
    
            }
    
            public void GetAccessToken()
            {
                string code = "";
                string google_client_id = "";
                string google_client_sceret = "";
                string google_redirect_url = "http://localhost:2216/index.aspx";
    
                /*Get Access Token and Refresh Token*/
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
                webRequest.Method = "POST";
                string parameters = "code=" + code + "&client_id=" + google_client_id + "&client_secret=" + google_client_sceret + "&redirect_uri=" + google_redirect_url + "&grant_type=authorization_code";
                byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = byteArray.Length;
                Stream postStream = webRequest.GetRequestStream();
                // Add the post data to the web request
                postStream.Write(byteArray, 0, byteArray.Length);
                postStream.Close();
                WebResponse response = webRequest.GetResponse();
                postStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(postStream);
                string responseFromServer = reader.ReadToEnd();
                GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);
                /*End*/
                GetContacts(serStatus);
            }
            public Feed<Contact> GetContacts(GooglePlusAccessToken serStatus)
            {
                string refreshToken = serStatus.refresh_token;
                string accessToken = serStatus.access_token;
                string scopes = "https://www.google.com/m8/feeds/contacts/default/full/";
                OAuth2Parameters oAuthparameters = new OAuth2Parameters()
                {
                    RedirectUri = "http://localhost:2216/index.aspx",
                    Scope = scopes,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
    
    
                RequestSettings settings = new RequestSettings("<var>YOUR_APPLICATION_NAME</var>", oAuthparameters);
                ContactsRequest cr = new ContactsRequest(settings);
                ContactsQuery query = new ContactsQuery(ContactsQuery.CreateContactsUri("default"));
                query.NumberToRetrieve = 5000;
                Feed<Contact> feed = cr.Get<Contact>(query);
    
                return feed;
            }
    
        }
    }
