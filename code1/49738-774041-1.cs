    DataTable t = MyDataSet["TableA"];
    t.TableNewRow += new delegate(object sender, DataTableNewRowEventArgs e)
       {
          r.Row["ID"] = SequenceHelper.GetNextID();
       };
