                #region JSON.Net User Profile
                //Profile URL
                url = "https://graph.facebook.com/me?fields=id,name,email&access_token=" + oAuth.Token;
                JObject myProfile = JObject.Parse(requestFBData(url));
                string myID = myProfile["id"].ToString().Replace("\"", "");
                string myName = myProfile["name"].ToString().Replace("\"", "");
                string email = myProfile["email"].ToString().Replace("\"", "");
                lblID.Text = myID;
                lblFullName.Text = myName;
                lblEmail.Text = email;
                imgUser.ImageUrl = "https://graph.facebook.com/me/picture?type=large&access_token=" + oAuth.Token;
                #endregion
 
                
                #region JSON.Net Friends
                
                //Friends URL
                url = "https://graph.facebook.com/me/friends?access_token=" + oAuth.Token;
                
                JObject myFriends = JObject.Parse(requestFBData(url));
                string id="";
                string name = "";
                
                //Loop through the returned friends
                foreach (var i in myFriends["data"].Children())
                {
                    id = i["id"].ToString().Replace("\"", "");
                    name = i["name"].ToString().Replace("\"", "");
                    lblFriends.Text = lblFriends.Text + "<br/> " + "id: " + id + " name: " + name + "<img src=" + "https://graph.facebook.com/" + id + "/picture>";
                }
                
                #endregion
                
            }
        }
    }
    public string requestFBData(string action)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(action);
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        StreamReader sr = new StreamReader(resp.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();
        return results;
    }
    
