    public DataSet datos_referencias()
    {
        DataSet ds = new DataSet();
        DataTable tabla_detallado = new DataTable("Clientes");
        tabla_detallado.Columns.Add(new DataColumn("Cliente", typeof(string)));
        objeto = new Conexion();
        try
        {
            objeto.abrir_conexion_mysql();
            objeto.cadena_comando_mysql = "SELECT * from ...ETC ";
            objeto.aplicar_comando_mysql_extraccion();
            while (objeto.leer_comando.Read())
            {
                DataRow fila = tabla_detallado.NewRow();
                fila["Cliente"] = (objeto.leer_comando.GetString(1)).ToUpper();                
                tabla_detallado.Rows.Add(fila);
            }
            
        }
        finally {objeto.cerrar_conexion_mysql_extraccion(); }
        ds.Tables.Add(tabla_detallado);
        return ds;
    }
