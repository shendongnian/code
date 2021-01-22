            DataTable t= new DataTable();
            t.Columns.Add("id");
            t.Columns.Add("id2");
            t.Columns.Add("id3", typeof(int), "IIF(id="+int.MinValue.ToString()+",id2,id+id2)");
            for (int i = 0; i < 5; i++)
            {
                t.Rows.Add(new object[] { i, 2 * i });
            }
            t.Rows.Add(new object[] { int.MinValue, 2000});
