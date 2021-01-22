    public class Field
    {
      List<FieldRow> fieldRow;
    
      public void DeleteByKey(int key)
      {
        fieldRow.RemoveAll(row => key == row.key);
      }
    }
    
    public class FieldRow
    {
      public int key;
    }
    
