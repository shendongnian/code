        private void UpdateFont()
        {
            //Change cell font
            foreach(DataGridViewColumn c in dgAssets.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 8.5F, GraphicsUnit.Pixel);
            }
        }
