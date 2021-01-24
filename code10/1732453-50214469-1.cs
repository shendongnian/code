    try
    {
        return strngarray.Select(strngarrayelem =>
        {
            string[] data = strngarrayelem .Split(',');
    
            return new xyzClass(data[1], data[2], data[0], (Color)System.Windows.Media.ColorConverter.ConvertFromString(data[3]), data.Length > 4 ? data[4] : "N/A");
        }).ToList(); // <------- HERE !!!
    }
    catch (Exception ex)
    {
        MessageBox.Show("abc");
        return Enumerable.Empty<xyzClass>();
    }
