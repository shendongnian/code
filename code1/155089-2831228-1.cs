    class A
    {
        public int ID{get;set;}
        public string Name{get;set;}
    }
    cbo.DataSource = new A[]{new A{ID=1, Name="hello"}};
    cbo.DisplayMember = "Name";
    cbo.DisplayValue = "ID";
    int id = Convert.ToInt32(cbo.SelectedValue);
    A a = (A) cbo.SelectedItem;
    int a_id = a.ID;
    int a_name = a.Name;
