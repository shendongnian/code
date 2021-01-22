                        dc.DataType = typeof(string);
                    }
                    dtGroup.AcceptChanges();
                    foreach (string s in srLead)
                    {
                        string name = s;
                        DataTable dtsource = new DataTable();
                        dtsource = TeamLeadFilter(dtResult, name);
                        CombineDatatable(ref dtGroup, dtsource);
                        dtGroup.AcceptChanges();
                    }
                    #endregion
