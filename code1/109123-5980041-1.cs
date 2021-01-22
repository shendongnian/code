    // class
    public class stringInt
    {
        public string Nombre;
        public int orden;
    }
    // function
    
    static public DataTable AlphabeticDataTableColumnSort(DataTable dtTable)
    {
        //vamos a extraer todos los nombres de columnas, meterlos en una lista y ordenarlo
        int orden = 1;
        List<stringInt> listaColumnas = new List<stringInt>();
         
        foreach (DataColumn dc in dtTable.Columns)
        {
            stringInt columna = new stringInt();
            columna.Nombre = dc.Caption;
            if ((dc.Caption != "Problema") && (dc.Caption != "Nombre")) columna.orden = 1;
            else columna.orden = 0;
            listaColumnas.Insert(0,columna);
         }
         listaColumnas.Sort(delegate(stringInt si1, stringInt si2) { return si1.Nombre.CompareTo(si2.Nombre); });
            
         // ahora lo tenemos ordenado por nombre de columna
         foreach (stringInt si in listaColumnas)
         { 
             // si el orden es igual a 1 vamos incrementando
             if (si.orden != 0)
             {
                 si.orden = orden;
                 orden++;
             }
          }
          listaColumnas.Sort(delegate(stringInt si1, stringInt si2) { return si1.orden.CompareTo(si2.orden); });
           // tenemos la matriz con el orden de las columnas, ahora vamos a trasladarlo al datatable
           foreach(stringInt si in listaColumnas)
              dtTable.Columns[si.Nombre].SetOrdinal(si.orden);
         
            return dtTable;
    }
