     this.picker = new DateTimePicker
            {
                Checked = false,
                Font = new System.Drawing.Font("Verdana", 9.75F),
                Format = System.Windows.Forms.DateTimePickerFormat.Time,
                Location = new System.Drawing.Point(5, 5),
                Name = "picker",
                ShowUpDown = true,
                Size = new System.Drawing.Size(120, 23),
                Visible = false
            };
            this.Controls.Add(this.picker);
            this.picker.Visible = true;
            this.picker.Value = this.picker.Value.Date.AddHours(1);
