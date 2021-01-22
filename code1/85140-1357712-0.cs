    public Image CargarAvatar(string login)
    {
        System.Object[] Args = new System.Object[1];
        Args[0] = login;
    
        DataTable X = TraerDataTable("sp_CargarAvatarUsuario", Args); // No need to create a new DataTable and overwrite it with the return value of TraerDataTable. One assignment will do.
    
        byte[] ImagemByte = (byte[])X.Rows[0][0]; // If this is an Image in the database, then this is already a byte[] here and just needs to be casted like so.             
    
        MemoryStream ms = new MemoryStream(ImagemByte); // You need to pass the existing byte[] into the constructor of the stream so that it goes against the correct data
        Image returnImage = Image.FromStream(ms);
        return returnImage;
    }
