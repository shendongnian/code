     public void GetMonthList(DropDownList ddl)
        {
            DateTime month = Convert.ToDateTime("1/1/2000");
            for (int i = 0; i < 12; i++)
            {
                DateTime NextMont = month.AddMonths(i);
                ListItem list = new ListItem();
                list.Text = NextMont.ToString("MMMM");
                list.Value = NextMont.Month.ToString();
                ddl.Items.Add(list);
            }
            //ddl.Items.Insert(0, "Select Month");
            ddl.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
        }
