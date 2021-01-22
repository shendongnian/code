    public List Compare2(TestStruct inTestStruct)
    {
      List diffs = new List();
      FieldInfo[] fields = this.GetType().GetFields();
      FieldInfo[] fields2 = inTestStruct.GetType().GetFields();
      for (int i = 0; i < fields.Length; i++)
      {
         object value1 = fields[i].GetValue(this);
         object value2 = fields2[i].GetValue(inTestStruct);
         if (!value1.Equals(value2))
         {
            diffs.Add(new Diff(fields[i].Name, value1, value2));
         }
      }
      return diffs;
    }
