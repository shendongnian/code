         public List<Diff> Compare2(TestStruct inTestStruct)
         {
            List<Diff> diffs = new List<Diff>();
            Type objectType = this.GetType();
            Type objectType2 = inTestStruct.GetType();
            FieldInfo[] fields = objectType.GetFields();
            FieldInfo[] fields2 = objectType2.GetFields();
            for (int i = 0; i &lt fields.Length; i++)
            {
               if(fields[i].Name.Equals(fields2[i].Name))
               {
                  diffs.Add(new Diff(fields[i].Name, fields[i].GetValue(this), fields2[i].GetValue(inTestStruct)));
               }
            }
            return diffs;
         }
