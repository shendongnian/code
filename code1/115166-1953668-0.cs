        if (!IsPostBack)
        {
            var abbr = from c in DB.Departments
                       where c.DepartmentAbbr != "BInst"
                       select c;
            foreach (var c in abbr)
            {
                String s = String.Format("{0} - ({1})", c.DepartmentAbbr, c.DepartmentName);
                rcbDepartments.Items.Add(new RadComboBoxItem(s, c.DepartmentID.ToString()));
            }
        }
    }
