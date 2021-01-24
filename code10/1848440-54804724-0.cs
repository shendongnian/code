    using (IRISInSiteLiveEntities DB = new IRISInSiteLiveEntities())
            {
                var allsites = DB.Sites.ToList();
                Debug.Write("Starting Site Update loop...");
                //Loop through sites and the OOB list and if they match then tell us
                //750 records takes around 15-20 minutes.
                foreach( var oobdata in oob_data)
                {
                    foreach( var sitedata in allsites)
                    {
                        var indexof = sitedata.SiteName.IndexOf(' ');
                        if( indexof > 0 )
                        {
                            var OOBNo = oobdata.SiteNo;
                            var OOBName = oobdata.SiteName;
                            var SiteNo = sitedata.SiteName;
                            var split = SiteNo.Substring(0, indexof);
                            if (OOBNo == split && SiteNo.Contains(OOBName) )
                            {
                                sitedata.CabinOOB = oobdata.CabinOOB;
                                sitedata.TowerOOB = oobdata.TowerOOB;
                                sitedata.ManagedOOB = oobdata.ManageOOB;
                                sitedata.IssueDescription = oobdata.Description;
                                sitedata.TargetResolutionDate = oobdata.TargetResolutionDate;
                                Debug.Write("Thank you, next: " + sitedata.Id + "\n");
                            }
                        }
                       
                    }
                }
                DB.SaveChanges();
            }
