    [HttpPost]
        public string GetData()
        {
            string sJSONResponse = "";
            List<string> data = new List<string>();
            using (var context = new RSAT.Api.Data.Proxy.ATT2018NOVUSContext())
            {
                var baseViewModel = (from userinfo in context.Userinfo
                                     join department in context.Dept on userinfo.Deptid equals department.Deptid
                                     select new
                                     {
                                         Id = userinfo.Userid,
                                         Name = userinfo.Name,
                                         Department = department.DeptName,
                                         CardNumber = userinfo.CardNum,
                                         Status = userinfo.UserFlag.ToString(),
                                         HistoryOfStatuses = (from checkinout in context.Checkinout
                                                              join status in context.Status on checkinout.CheckType equals status.Statusid
                                                              where checkinout.Userid == userinfo.Userid
                                                              orderby checkinout.CheckTime descending
                                                              select new Checkinout
                                                              {
                                                                  CheckStatus = status.StatusText,
                                                                  CheckTime = checkinout.CheckTime
                                                              }).ToList(),
                                     }).ToList();
                
                foreach (var i in baseViewModel)
                {
                    foreach (var h in i.HistoryOfStatuses)
                    {
                        var s = "[\"" + h.CheckStatus + "\"," + "\"" + h.CheckTime + "\"]";
                        data.Add(s);
                    }
                }
                string dataRez = "[";
                foreach (var i in data)
                {
                    dataRez += i + ",";
                }
                dataRez = dataRez.Remove(dataRez.Length - 1);
                dataRez = dataRez + "]";
                sJSONResponse = "{\"draw\": 1,\"recordsTotal\": 57,\"recordsFiltered\": 57,\"data\":" + dataRez + "}";
            }
            return sJSONResponse;
        }
