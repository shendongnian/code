     public List<tbltask> gettaskssdata(int? c, int? userid, string a, string StartDate, string EndDate, int? ProjectID, int? statusid)
            {
                List<tbltask> tbtask = new List<tbltask>();
                DateTime sdate = (StartDate != "") ? Convert.ToDateTime(StartDate).Date : new DateTime();
                DateTime edate = (EndDate != "") ? Convert.ToDateTime(EndDate).Date : new DateTime();
                tbtask = entity.tbltasks.Include(x => x.tblproject).Include(x => x.tbUser).
                    Where(x => x.tblproject.company_id == c
                        && (ProjectID == 0 || ProjectID == x.tblproject.ProjectId)
                        && (statusid == 0 || statusid == x.tblstatu.StatusId)
                        && (a == "" || (x.TaskName.Contains(a) || x.tbUser.User_name.Contains(a)))
                        && ((StartDate == "" && EndDate == "") || ((x.StartDate >= sdate && x.EndDate <= edate)))).ToList();
                return tbtask;
            }
