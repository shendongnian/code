                // Index 26 is Diabetic Teaching
            harDataSet = myHARTableMaint.GetMaintItem(26);
            harDataTable = harDataSet.Tables[0];
            lkuDiabeticTeaching.Properties.DataSource = harDataTable;
            lkuDiabeticTeaching.Properties.ForceInitialize();
            lkuDiabeticTeaching.Properties.PopulateColumns();
            lkuDiabeticTeaching.Properties.DisplayMember = "ItemDescription";
            lkuDiabeticTeaching.Properties.ValueMember = "ItemID";
            if(lkuDiabeticTeaching.Properties.Columns.Count > 0)
            {
                lkuDiabeticTeaching.Properties.Columns[0].Visible = false;
                lkuDiabeticTeaching.Properties.Columns[1].Visible = false;
                lkuDiabeticTeaching.Properties.Columns[3].Visible = false;
                lkuDiabeticTeaching.Properties.Columns[4].Visible = false; 
            }
