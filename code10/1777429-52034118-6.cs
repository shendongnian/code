        public int CurrentID
        {
            get
            {
                int tmp = 0;
                if (dg_address.SelectedIndex >= 0)
                {
                    int.TryParse(dtAddress.Rows[dg_address.SelectedIndex].ItemArray[0].ToString(), out tmp);
                }
                return tmp;
            }
        }
        public void SetToRow(int Id)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            dg_address.SelectionChanged -= DG_Address_SelectionChanged;
            while (CurrentID != Id && dg_address.SelectedIndex < dtAddress.Rows.Count - 1)
            {
                dg_address.SelectedIndex++;
            }
            dg_address.SelectionChanged += DG_Address_SelectionChanged;
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }
