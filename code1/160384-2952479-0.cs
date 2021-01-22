    DropDownBox box = FlattenHierachy(Page)
       .Where(c => c is DropDownList)
       .Cast<DropDownList>()
       .Where(d => d.SelectedIndex != -1)
       .FirstOrDefault();
    if (box != null)
    {
       if (box.ID.StartsWith("GenInfo_"))
       {
          GenInfo = true;
       }
       if (box.ID.StartsWith("EmpInfo_"))
       {
           EmpInfo = true;
       }
    }
       
