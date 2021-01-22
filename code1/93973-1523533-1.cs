    using (SqlDataReader sdr=cmd.ExecuteReader(CommandBehavior.SequentialAccess))
    {
    ...
    System.Data.SqlTypes.SqlBytes imageBytes = srd.GetSqBytes(2);
    System.Drawing.Image locationImage = Image.FromStream(imageBytes.Stream);
    }
