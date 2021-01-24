    string[] myArray = new string[] { "Alex", "Bob", "John", "Srinivas", "Zamal", "Rahul" }
                foreach (string item in myArray)
                {
                    HyperLink myHyp = new HyperLink();
                    myHyp.Text = Suspect;
                    myHyp.NavigateUrl = "User Details.aspx?name=" + HttpUtility.UrlEncode(item));
                    myPanel.Controls.Add(new LiteralControl("<ul>"));
                    myPanel.Controls.Add(new LiteralControl("<li>"));
                    myPanel.Controls.Add(hpSuspect);
                    myPanel.Controls.Add(new LiteralControl("</li>"));
                    myPanel.Controls.Add(new LiteralControl("</ul>"));
                }
