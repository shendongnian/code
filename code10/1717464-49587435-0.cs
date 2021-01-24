    int rowNum = 1;
        public void tett() {
            Control[] controlsToAdd = { new TextBox(), new TextBox(), new ComboBox(), new TextBox(), new TextBox(), new TextBox(), new Button() };
            string[] labels = { "Product", "Quantity", "Unit", "Total Price", "Unit Purchase", "Unit Sell Price" };
            Panel whitePanel = new Panel() {
                Name = "wt",
                Dock = DockStyle.Top,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                AutoSize = true,
                Padding = new Padding(0, 5, 0, 5),
                BackColor = ColorTranslator.FromHtml("#ECF0F5")
            };
            int controlX = 5, controlY = 15, controlDistance = 15;
            for (int i = 0; i < controlsToAdd.Length; i++) {
                if (labels.Length > i) {
                    var label = new Label() {
                        Text = labels[i],
                        Location = new Point(controlX, controlY)
                    };
                    whitePanel.Controls.Add(label);
                }
                var control = controlsToAdd[i];
                control.Location = new Point(controlX, controlY + 23);
                control.Size = new Size(120, 24);
                if (control is Button) {
                    control.Name = "disposeButton" + i;
                    control.Text = "Dispose";
                    control.Click += _button_MouseClick;
                } else {
                    if(i == 0) { //if it is the Product textbox
                        ((TextBox)control).AutoCompleteSource = AutoCompleteSource.CustomSource;
                        ((TextBox)control).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        //control.MouseClick += textBox5_MouseClick;
                    }
                    control.Name = "Text" + i;
                    control.Text = "Row" + rowNum + " Text" + i;
                }
                whitePanel.Controls.Add(control);
                controlX += 120 + controlDistance;
            }
            panel1.Controls.Add(whitePanel);
            whitePanel.BringToFront();
            rowNum++;
        }
        private void _button_MouseClick(object sender, EventArgs e) {
            //button does its job here
            ((Button)sender).Parent.Parent.Controls.Remove(((Button)sender).Parent);
        }
        public SqlConnection Conn { get; }
        void save() {
            foreach(Panel whitePanel in panel1.Controls) {
                var sqlString = "INSERT INTO products(productField, quantityField, unitField, priceField, purchaseField, sellPriceField) VALUES (";
                foreach (Control control in whitePanel.Controls) {
                    if(!(control is Label) && !(control is Button)) { //So, textbox or combobox remained
                        sqlString += "'"+ control.Text +"', ";
                    }
                }
                sqlString = sqlString.Substring(0, sqlString.Length - 2) + ")";
                //Assume you have previous construction of SqlConnection as name "Conn"
                if (Conn != null) {
                    if (Conn.State != ConnectionState.Open) Conn.Open();
                    using (var cmd = new SqlCommand(sqlString, Conn)) {
                        cmd.ExecuteNonQuery();
                    }
                    Conn.Close();
                }
                Console.WriteLine(sqlString);
            }
        }
