    public static int[] LoadFormLocationAndSize(Form xForm)
    {
        int[] LocationAndSize = new int[] { xForm.Location.X, xForm.Location.Y, xForm.Size.Width, xForm.Size.Height };
        //---//
        try
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            var AbbA = config.AppSettings.Settings[xForm.Name].Value.Split(';');
            //---//
            LocationAndSize[0] = Convert.ToInt32(AbbA.GetValue(0));
            LocationAndSize[1] = Convert.ToInt32(AbbA.GetValue(1));
            LocationAndSize[2] = Convert.ToInt32(AbbA.GetValue(2));
            LocationAndSize[3] = Convert.ToInt32(AbbA.GetValue(3));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        //---//
        return LocationAndSize;
    }
