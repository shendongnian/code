    public static Task<List<ObtenerLayoutPor_Result>> GenerarArchivoPorBanco()
    {
            using (CobranzaEntities db = new CobranzaEntities())
            {
                return db.ObtenerLayoutPor(96).ToListAsync();
            }
    }
