    while (ur.Read())
            {
                object[] objUsers = {
                    ur["ApplicationId"].ToString(),
                    ur["UserId"].ToString(),
                    ur["UserName"].ToString(),
                    ur["MobileAlias"].ToString(),
                    ur["LastActivityDate"].ToString(),
                    ur["Name"].ToString(),
                    ur["Phone"].ToString(),
                    ur["Email"].ToString(), };
                myDataUsers.Rows.Add(objUsers);
                conn.Close();
            }
