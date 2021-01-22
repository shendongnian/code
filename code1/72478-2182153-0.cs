        private Int32 tlpRowCount = 0;
        private void BindAddress()
        {
            Addlabel(Addresses.Street);
            if (!String.IsNullOrEmpty(Addresses.Street2))
            {
                Addlabel(Addresses.Street2);
            }
            Addlabel(Addresses.CityStateZip);
            if (!String.IsNullOrEmpty(Account.Country))
            {
                Addlabel(Address.Country);
            }
            Addlabel(String.Empty); // Notice the empty label...
        }
        private void Addlabel(String text)
        {            
            label = new Label();
            label.Dock = DockStyle.Fill;
            label.Text = text;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tlpAddress.Controls.Add(label, 1, tlpRowCount);
            tlpRowCount++;
        }
