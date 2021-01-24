    private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			// Determine the CheckState of the check box.  
			if (checkBox1.CheckState == CheckState.Checked)
			{
				groupBox1.Controls.Add(combo);
				combo.Items.AddRange(new object[] {
					"Item 1",
					"Item 2",
					"Item 3",
					"Item 4",
					"Item 5",
					"Item 6"});
				combo.Location = new System.Drawing.Point(19, 123);
				combo.Name = "combo";
				combo.Size = new System.Drawing.Size(121, 21);
				combo.TabIndex = 0;
				combo.SelectedIndexChanged += new System.EventHandler(this.combo_SelectedIndexChanged);
				combo.BringToFront();
				
				this.AllowDrop = false;
    }
    
