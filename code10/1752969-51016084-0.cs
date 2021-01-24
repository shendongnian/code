            for (int j = 0; j < Data.BTN_Name.Count; j++)
            {
                Product[j] = new ListBox()
                {
                    Location = new Point(20 * j, 70),
                    Width = 200,
                    Height = 250,
                    Visible = false,
                };
                this.Controls.Add(Product[j]);
                var captured_j = j;
                Category[j].Click += (s, ea) => Product[captured_j].Visible = true;
            }
