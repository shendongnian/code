            var query = from c in db.Students select c;
            if (Request.QueryString["Name"] != null)
            {
                name = Request.QueryString["Name"];
                query = query.Where(c => c.name == name);
            }
            if (Request.QueryString["Type"] != null)
            {
                type += Request.QueryString["Type"];
                query = query.Where(c => c.type == type);
            }
            GridView1.DataSource = query.ToList()
