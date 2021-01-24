    List<string> result = new List<string>();
            using (XamarinEntities entities = new XamarinEntities())
            {
                result = entities.appinfoes.AsEnumerable().Where(x => x.approveduser == null || x.approveduser=="No").Select(y =>  "ID = "+y.ID+", fname = "+ y.fname+", lname = "+ y.lname+", phone = "+ y.phone+", company = "+ y.company).ToList();
            }
    return JsonConvert.SerializeObject(result);
