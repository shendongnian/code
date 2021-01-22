     sp_Select_PersonTableAdapter adapter = new sp_Select_PersonTableAdapter();
     dgvPerson.DataSource = adapter.GetData();
                    
     DataTable tbl = new DataTable();
     tbl.Merge(adapter.GetData());
     List<Person> list = tbl.AsEnumerable().Select(x => new Person
     {
         Id = (Int32) (x["Id"]),
         Ime = (string) (x["Name"] ?? ""),
         Priimek = (string) (x["LastName"] ?? "")
     }).ToList();
    
     BindingList<Person> bindingList = new BindingList<Person>(list);
        
     BindingSource bindingSource = new BindingSource();
     bindingSource.DataSource = bindingList;
     dgvPerson.DataSource = bindingSource;
