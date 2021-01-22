    SqlMembershipProvider ObjSqlMembershipProvider = new SqlMembershipProvider();
                SqlRoleProvider ObjSqlRoleProvider = new SqlRoleProvider();
                NameValueCollection ObjNameValueCollRole = new NameValueCollection();
                NameValueCollection ObjNameValueCollMembership = new NameValueCollection();
                MembershipCreateStatus enMembershipCreateStatus;
                try
                {
                    ObjNameValueCollMembership.Add("connectionStringName", "Connection String Name");
                    ObjNameValueCollMembership.Add("applicationName", "ApplicatioNAme");
                    //these items are assumed to be Default and dont care..Should be given a look later stage.
                    ObjNameValueCollMembership.Add("enablePasswordRetrieval", "false");
                    ObjNameValueCollMembership.Add("enablePasswordReset", "false");
                    ObjNameValueCollMembership.Add("requiresQuestionAndAnswer", "false");
                    ObjNameValueCollMembership.Add("requiresUniqueEmail", "false");
                    ObjNameValueCollMembership.Add("passwordFormat", "Hashed");
                    ObjNameValueCollMembership.Add("maxInvalidPasswordAttempts", "5");
                    ObjNameValueCollMembership.Add("minRequiredPasswordLength", "1");
                    ObjNameValueCollMembership.Add("minRequiredNonalphanumericCharacters", "0");
                    ObjNameValueCollMembership.Add("passwordAttemptWindow", "10");
                    ObjNameValueCollMembership.Add("passwordStrengthRegularExpression", "");
                    //hard coded the Provider Name,This fuction just need one that is present. I tried other names and it throws error. I found this using Reflector ..all the rest are take care by the above
                    //name value pairs
                    ObjSqlMembershipProvider.Initialize("AspNetSqlMembershipProvider", ObjNameValueCollMembership);         
