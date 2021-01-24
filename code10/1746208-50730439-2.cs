    if (file.ShowDialog() == DialogResult.OK)
    {
        try
        {
            gpsGGA.Clear();
            gpsRMC.Clear();
            string[] lines= File.ReadAllLines(file.FileName);
            foreach(String line in lines)
            {
               string[] substring = line.Split(';');
               gpsGGA.Add(substring[11]);
               gpsRMC.Add(substring[12]);
            }
            
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
