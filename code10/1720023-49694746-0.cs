    var listOfParks = (from s in DB.MasterDatas
    
                               select new SelectListItem
                               {
                                   Text = s.service_under,
    
                               }).Distinct().Union(
                               from t in DB.MasterDatas
                                join f in DB.Users1
                               on t.pv_person_resp_id equals f.user_id     
                               select new SelectListItem
                               {
                                   Text = f.user_name
    
                               }).ToList();
    listOfParks.Add(new SelectListItem{Text="All"});
