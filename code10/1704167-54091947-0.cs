     using (DataTable comTable = new DataTable())
                {
                    comTable.Columns.Add(new DataColumn("AppId"));
                    comTable.Columns.Add(new DataColumn("Name"));
                    comTable.Columns.Add(new DataColumn("Local Service"));
                    comTable.Columns.Add(new DataColumn("Authentication Level"));
                    comTable.Columns.Add(new DataColumn("RunAsUser"));
                    comTable.Columns.Add(new DataColumn("Identity"));
                    comTable.Columns.Add(new DataColumn("Access Permissions"));
                    comTable.Columns.Add(new DataColumn("Launch and Activation Permissions"));
                    comTable.DefaultView.Sort = "Name ASC";
                    string query = ControlConstant.GETDCOMCONFIG;
                    using (var moDisposer = new ManagementObjectDisposer())
                    {
                        var managementObj = moDisposer.Search(query, msScope);
                        foreach (ManagementBaseObject dConfig in managementObj)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dConfig["Caption"])))
                            {
                                string szAppId;
                                DataRow row = comTable.NewRow();
                                szAppId = Convert.ToString(dConfig["AppID"]);
                                row["AppId"] = Convert.ToString(dConfig["AppID"]);
                                row["Name"] = Convert.ToString(dConfig["Caption"]);
                                row["Local Service"] = Convert.ToString(dConfig["LocalService"]);
                                row["Authentication Level"] = Convert.ToString(dConfig["AuthenticationLevel"]);
                                row["RunAsUser"] = Convert.ToString(dConfig["RunAsUser"]);
                                row["Identity"] = Convert.ToString(dConfig["RunAsUser"]);
                                row["Access Permissions"] = Utility.LaunchProcess(Utility.GetRootFolder() + "\\DComPerm.exe", "-aa " + szAppId + " list").ReadToEnd();
                                row["Launch and Activation Permissions"] = Utility.LaunchProcess(Utility.GetRootFolder() + "\\DComPerm.exe", "-al " + szAppId + " list").ReadToEnd();
                                comTable.Rows.Add(row);
                            }
                        }
                    }
