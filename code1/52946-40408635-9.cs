        public static string[] GetUserProperties(string strUserName)
        {
            UserPrincipal up = GetUser(strUserName);
            if (up != null)
            {
                string firstName = up.GivenName;
                string lastName = up.Surname;
                string middleInit = String.IsNullOrEmpty(up.MiddleName) ? "" : up.MiddleName.Substring(0, 1);
                string email = up.EmailAddress;
                string location = String.Empty;
                string phone = String.Empty;
                string office = String.Empty;
                string dept = String.Empty;
                DirectoryEntry de = (DirectoryEntry)up.GetUnderlyingObject();
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.PropertiesToLoad.Add("l"); // city field, a.k.a location
                ds.PropertiesToLoad.Add("telephonenumber");
                ds.PropertiesToLoad.Add("department");
                ds.PropertiesToLoad.Add("physicalDeliveryOfficeName");
                SearchResultCollection results = ds.FindAll();
                if (results != null && results.Count > 0)
                {
                    ResultPropertyCollection rpc = results[0].Properties;
                    foreach (string rp in rpc.PropertyNames)
                    {
                        if (rp == "l")  // this matches the "City" field in AD properties
                            location = rpc["l"][0].ToString();
                        if (rp == "telephonenumber")
                            phone = FormatPhoneNumber(rpc["telephonenumber"][0].ToString());                       
                        if (rp == "physicalDeliveryOfficeName")
                            office = rpc["physicalDeliveryOfficeName"][0].ToString();  
                        if (rp == "department")
                            dept = rpc["department"][0].ToString();
                    }
                }
                string[] userProps = new string[10];
                userProps[0] = strUserName;
                userProps[1] = firstName;
                userProps[2] = lastName;
                userProps[3] = up.MiddleName;
                userProps[4] = middleInit;
                userProps[5] = email;
                userProps[6] = location;  
                userProps[7] = phone;  
                userProps[8] = office;
                userProps[9] = dept;
                return userProps;
            }
            else
                return null;
        }
        /// <summary>
        /// Returns a UserPrincipal (AD) user object based on string userID being supplied
        /// </summary>
        /// <param name="strUserName">String form of User ID:  domain\username</param>
        /// <returns>UserPrincipal object</returns>
        public static UserPrincipal GetUser(string strUserName)
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain);
            try
            {
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, strUserName);
                return oUserPrincipal;
            }
            catch (Exception ex) { return null; }
        }
        public static string FormatPhoneNumber(string strPhoneNumber)
        {
            if (strPhoneNumber.Length > 0)
                //  return String.Format("{0:###-###-####}", strPhoneNumber);  // formating does not work because strPhoneNumber is a string and not a number
                return Regex.Replace(strPhoneNumber, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            else
                return strPhoneNumber;
        }
