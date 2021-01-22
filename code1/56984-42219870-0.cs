     ComboBox cbNew = new ComboBox();
        cbNew.Name = "cbLine" + (i+1);
        cbNew.Size = cbLine1.Size;
        cbNew.Location = new Point(cbLine1.Location.X, cbLine1.Location.Y + 26*i);
        cbNew.Enabled = false;
        cbNew.DropDownStyle = ComboBoxStyle.DropDownList;
        cbNew.DataSource = DBLayer.GetTeams(lineName).Tables[0];
        cbNew.DisplayMember = "teamdesc";
        cbNew.ValueMember = "id";
        Console.WriteLine("ComboBox {0}, itemcount={1}", cbNew.Name, cbNew.Items.Count);
            // The output displays itemcount = 0 for run-time created controls
            // and >0 for controls created at design-time
        gbLines.Controls.Add(cbNew);
