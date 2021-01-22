    public static DataTable Copy(this DatTable original)
    {
       var result = new DataTable();
       //assume Property1 was a property of a DataTable
       result.Property1 = original.Property1; 
       //continue copying state from original to result
       return result;
    }
