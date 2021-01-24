        private List<string> GetGroups()
        {
            string UPN = UserPrincipal.Current.UserPrincipalName.ToString();
            List<string> result = new List<string>();
            WindowsIdentity wi = new WindowsIdentity(UPN);
            foreach (IdentityReference group in wi.Groups)
            {
                string GroupName = group.Translate(typeof(NTAccount)).ToString();
                //if text location and lob is in the name add to results
                if (GroupName.Contains("Location") && GroupName.Contains("LOB"))
                {
                    string DataValue1 = GroupName.Substring(GroupName.Length - 3);
                    string DataValue2 = GroupName.Substring(GroupName.Length - 10, 2);
                    string DataValue = DataValue2 + "," + DataValue1;
                    result.Add(DataValue);
                }
            }
            result.Sort();
            return result;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var db = new GPSE2Entities())
                {
                    for (int i = 0; i < GetGroups().ToArray().Length; i++)
                    {
                        string DataValue = GetGroups().ToArray()[i].ToString();
                        var locations = (from loc in db.LocationLOBViews
                                         where loc.DataValue == DataValue
                                         orderby loc.LocationNumber
                                         select loc).FirstOrDefault();
                        if (locations != null)
                        {
                            var item = new ListItem
                             {
                                 Text = locations.DataText,
                                 Value = locations.DataValue
                             };
                            ddlShops.Items.Add(item);
                        }
                    }
                }
                ddlShops.Items.Insert(0, "--Select Location and LOB--");
            }
        }
