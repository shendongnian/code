    DirectoryEntry de = new DirectoryEntry(_ldap);
                DirectorySearcher ds = new DirectorySearcher(de) { Filter = "(&(objectClass=user)(SamAccountName=" + logon_tb.Text + "))" };
                SearchResult sr = ds.FindOne();
                DirectoryEntry userEntry = sr.GetDirectoryEntry();
                if (fn_tb.Text != "")
                    userEntry.Properties["givenName"].Value = fn_tb.Text;
                else
                    userEntry.Properties["givenName"].Value = null;
                if (ln_tb.Text != "")
                    userEntry.Properties["sn"].Value = ln_tb.Text;
                else
                    userEntry.Properties["sn"].Value = null;
                if (dispName_tb.Text != "")
                    userEntry.Properties["displayName"].Value = dispName_tb.Text;
                else
                    userEntry.Properties["displayName"].Value = null;
                if (description_tb.Text != "")
                    userEntry.Properties["description"].Value = description_tb.Text;
                else
                    userEntry.Properties["description"].Value = null;
                if (office_tb.Text != "")
                    userEntry.Properties["physicalDeliveryOfficeName"].Value = office_tb.Text;
                else
                    userEntry.Properties["physicalDeliveryOfficeName"].Value = null;
                if (telephone_tb.Text != "")
                    userEntry.Properties["telephoneNumber"].Value = telephone_tb.Text;
                else
                    userEntry.Properties["telephoneNumber"].Value = null;
                if (mobile_tb.Text != "")
                    userEntry.Properties["mobile"].Value = mobile_tb.Text;
                else
                    userEntry.Properties["mobile"].Value = null;
                if (jobTitle_tb.Text != "")
                    userEntry.Properties["title"].Value = jobTitle_tb.Text;
                else
                    userEntry.Properties["title"].Value = null;
                if (department_tb.Text != "")
                    userEntry.Properties["department"].Value = department_tb.Text;
                else
                    userEntry.Properties["department"].Value = null;
                if (poBox_tb.Text != "")
                    userEntry.Properties["postOfficeBox"].Value = poBox_tb.Text;
                else
                    userEntry.Properties["postOfficeBox"].Value = null;
                if (homeFolder_tb.Text != "")
                    userEntry.Properties["homeDirectory"].Value = homeFolder_tb.Text;
                else
                    userEntry.Properties["homeDirectory"].Value = null;
                if (extAtt10_tb.Text != "")
                    userEntry.Properties["extensionAttribute10"].Value = extAtt10_tb.Text;
                else
                    userEntry.Properties["extensionAttribute10"].Value = null;
                if (extAtt11_tb.Text != "")
                    userEntry.Properties["extensionAttribute11"].Value = extAtt11_tb.Text;
                else
                    userEntry.Properties["extensionAttribute11"].Value = null;
                if (extAtt12_tb.Text != "")
                    userEntry.Properties["extensionAttribute12"].Value = extAtt12_tb.Text;
                else
                    userEntry.Properties["extensionAttribute12"].Value = null;
                if (extAtt13_tb.Text != "")
                    userEntry.Properties["extensionAttribute13"].Value = extAtt13_tb.Text;
                else
                    userEntry.Properties["extensionAttribute13"].Value = null;
                if (extAtt14_tb.Text != "")
                    userEntry.Properties["extensionAttribute14"].Value = extAtt14_tb.Text;
                else
                    userEntry.Properties["extensionAttribute14"].Value = null;
                if (extAtt15_tb.Text != "")
                    userEntry.Properties["extensionAttribute15"].Value = extAtt15_tb.Text;
                else
                    userEntry.Properties["extensionAttribute15"].Value = null;
                if (logon_tb.Text != "")
                    userEntry.Properties["SamAccountName"].Value = logon_tb.Text;
                else
                    userEntry.Properties["SamAccountName"].Value = null;
                if (idNumber_tb.Text != "")
                    userEntry.Properties["userPrincipalName"].Value = idNumber_tb.Text;
                else
                    userEntry.Properties["userPrincipalName"].Value = null;
                userEntry.CommitChanges();
                userEntry.Close();
