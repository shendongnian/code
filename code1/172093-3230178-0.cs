    VDSORDAL.PDC_VDSOREntities lg = new VDSORDAL.PDC_VDSOREntities();
                IEnumerable<VDSORDAL.tblUserPreference> ol;
                string userName = Membership.GetUser().UserName; //store the value
                ol = from login in lg.tblUserPreferences
                     where login.Username == userName 
                     select login;
    
                if (ol.Count() > 0)
                {
                    Session["VDS_MemberID"] = ol.First().MemberID;
                    Session["VDS_LocationID"] = ol.First().LocationID;
                    Session["VDS_Username"] = ol.First().Username;
    
                    lblMemberID.Text = Session["VDS_MemberID"].ToString();
                    lblLocationID.Text = Session["VDS_LocationID"].ToString();
                }
                else
                {
                }
              }
