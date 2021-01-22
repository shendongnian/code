    public static DataTable Copy(this DatTable original)
    {
       var result = new DataTable();
       result.Property1 = original.Property1; //assume it was a property of a DataTable
       //continue copying state from original to result
       return result;
    }
