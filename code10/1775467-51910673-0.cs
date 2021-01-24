        private void button1_Click(object sender, EventArgs e)
        {
            Control lastPanelContol = null;
            if (panel1.Controls.Count > 0)
                lastPanelContol = panel1.Controls[panel1.Controls.Count - 1];
            var newButton = new Button
            {
                Name = "btnDynamic" + panel1.Controls.Count,
                Text = "btnDynamic" + panel1.Controls.Count,
                Left = 20,
                Width = 100,
                Top = lastPanelContol == null ? 20 : lastPanelContol.Top + lastPanelContol.Height + 20
            };
            panel1.Controls.Add(newButton);
        }
