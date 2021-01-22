        /// <summary>
        /// Gets matches based on First and Last Names. 
        /// This function takes a list of acceptable properties:
        /// USERNAME
        /// MIDDLE_NAME
        /// MIDDLE_INITIAL
        /// EMAIL
        /// LOCATION
        /// POST
        /// PHONE
        /// OFFICE
        /// DEPARTMENT
        ///
        /// The DataTable returned will have columns with these names, and firstName and lastName will be added to a column called "NAME"
        /// as the first column, automatically.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="props"></param>
        /// <returns>DataTable of columns from "props" based on first and last name results</returns>
        public static DataTable GetUsersFromName(string firstName, string lastName, List<string> props)
        {
            string userId = String.Empty;
            int resultCount = 0;
            DataTable dt = new DataTable();
            DataRow dr;
            DataColumn dc;
            // Always set the first column to the Name we pass in
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "NAME";
            dt.Columns.Add(dc);
            // Establish our property list as columns in our DataTable
            if (props != null && props.Count > 0)
            {
                foreach (string s in props)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    if (!String.IsNullOrEmpty(s))
                    {
                        dc.ColumnName = s;
                        dt.Columns.Add(dc);
                    }
                }
            } 
            // Start our search
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal up = new UserPrincipal(ctx);
            if (!String.IsNullOrEmpty(firstName))
                up.GivenName = firstName;
            if (!String.IsNullOrEmpty(lastName))
                up.Surname = lastName;
            PrincipalSearcher srch = new PrincipalSearcher(up);
            srch.QueryFilter = up;
            using (PrincipalSearchResult<Principal> results = srch.FindAll())
            {
                if (results != null)
                {
                    resultCount = results.Count();
                    if (resultCount > 0)  // we have results
                    {
                        foreach (Principal found in results)
                        {
                            // Iterate results, set into DataRow, add to DataTable
                            dr = dt.NewRow();
                            dr["NAME"] = found.DisplayName;
                            if (props != null && props.Count > 0)
                            {
                                userId = GetUserIdFromPrincipal(found);
                                // Get other properties
                                string[] userProps = GetUserProperties(userId);
                                foreach (string s in props)
                                {
                                    if (s == "USERNAME")                   
                                        dr["USERNAME"] = userId;
                                    if (s == "MIDDLE_NAME")
                                        dr["MIDDLE_NAME"] = userProps[3];
                                    if (s == "MIDDLE_INITIAL")
                                        dr["MIDDLE_INITIAL"] = userProps[4];
                                    if (s == "EMAIL")
                                        dr["EMAIL"] = userProps[5];
                                    if (s == "LOCATION")
                                        dr["LOCATION"] = userProps[6];
                                    if (s == "PHONE")
                                        dr["PHONE"] = userProps[7];
                                    if (s == "OFFICE")
                                        dr["OFFICE"] = userProps[8];                                    
                                    if (s == "DEPARTMENT")
                                        dr["DEPARTMENT"] = userProps[9];
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt;
        }
