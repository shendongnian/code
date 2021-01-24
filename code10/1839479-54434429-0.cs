            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("ID");
            dt.Columns.Add("PAGE");
            dt.Columns.Add("GROUP");
            dt.Columns.Add("BARBUTTON");
            DataRow dr;
            List<BarItemLink> var = ribbonControl1.Pages.GetPageByName("ribbonPage1").Groups.GetGroupByText("ribbonPageGroup1").ItemLinks.ToList();
            foreach (DevExpress.XtraBars.BarItemLink bar in var)
            {
                dr = dt.NewRow();
                dr["BARBUTTON"] = bar.Caption; // bar.Item.Name; // bar.DisplayCaption;
                dt.Rows.Add(dr);
            }
