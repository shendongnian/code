    private async Task<ObservableCollection<ShiftPageListItemViewModel>> GetMapAsync()
    {
        mDbConnect = new DBConnect();
    
        var ShiftsTab = new DataTable();
    
        ShiftsTab = await mDbConnect.MapAsync(Date.ToString("yyyy-MM-dd"));
    
        var Map = new ObservableCollection<ShiftPageListItemViewModel>();
    
        await Task.Run(() =>
        {
            foreach (DataRow row in ShiftsTab.Rows)
            {
                var mapCollection = new ShiftPageListItemViewModel
                {
                    BorderTag = row[0].ToString(),
                    Name = row[1].ToString(),
                    HourTitle = ShiftsTab.Rows.IndexOf(row) < 10 ? $"Ora0{ShiftsTab.Rows.IndexOf(row)}" : $"Ora{ShiftsTab.Rows.IndexOf(row)}",
                    Ora00 = Convert.ToDouble(row[2].ToString()),
                    Ora01 = Convert.ToDouble(row[3].ToString()),
                    Ora02 = Convert.ToDouble(row[4].ToString()),
                    Ora03 = Convert.ToDouble(row[5].ToString()),
                    Ora04 = Convert.ToDouble(row[6].ToString()),
                    Ora05 = Convert.ToDouble(row[7].ToString()),
                    Ora06 = Convert.ToDouble(row[8].ToString()),
                    Ora07 = Convert.ToDouble(row[9].ToString()),
                    Ora08 = Convert.ToDouble(row[10].ToString()),
                    Ora09 = Convert.ToDouble(row[11].ToString()),
                    Ora10 = Convert.ToDouble(row[12].ToString()),
                    Ora11 = Convert.ToDouble(row[13].ToString()),
                    Ora12 = Convert.ToDouble(row[14].ToString()),
                    Ora13 = Convert.ToDouble(row[15].ToString()),
                    Ora14 = Convert.ToDouble(row[16].ToString()),
                    Ora15 = Convert.ToDouble(row[17].ToString()),
                    Ora16 = Convert.ToDouble(row[18].ToString()),
                    Ora17 = Convert.ToDouble(row[19].ToString()),
                    Ora18 = Convert.ToDouble(row[20].ToString()),
                    Ora19 = Convert.ToDouble(row[21].ToString()),
                    Ora20 = Convert.ToDouble(row[22].ToString()),
                    Ora21 = Convert.ToDouble(row[23].ToString()),
                    Ora22 = Convert.ToDouble(row[24].ToString()),
                    Ora23 = Convert.ToDouble(row[25].ToString()),
                };
    
                Map.Add(mapCollection);
            };
    
        }); 
        return Map;
    }
