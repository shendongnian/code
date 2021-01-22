    public List <Entities.ENFactura> ListaxIdFactura (SqlTransaction Tr, Entities.ENFactura oBEFactura)
    {
    
        SqlConnection Cn = new SqlConnection(); 
        Cn = _Connection.ConexionSEG();
    
        List<Entities.ENFactura> loBEFactura = new List<Entities.ENFactura>();
    
        using (Cn)
        {
            Cn.Open();
    
            SqlDataReader drd = (odaSQL.fSelDrd(Cn, Tr, "Pa_CC_Factura_Listar_x_IdProveedor", oBEFactura));
    
            if (drd != null)
    
            {
                if (drd.HasRows)
    
                {
    
                mapeador.MapearDataReaderListaObjetos <ENFactura>(drd, loBEFactura);
    
                }
            }
        }
    
    	return (loBEFactura);
    }
