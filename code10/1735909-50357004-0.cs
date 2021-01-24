        ItemsAdapter.AcceptChangesDuringUpdate = true;
        foreach ( DataRow Row in Items.AsEnumerable() )
        {
          if ( !_Items.TableContains("Item", Row["Item"]) )
          { ItemsTable.Rows.Add(Row); }
          else if ( _Items.TableContains("Item", Row["Item"]) )
          {
            ItemsTable.AsEnumerable()
                      .Join(Items.AsEnumerable(), r1 => r1.ItemArray[0], r2 => r2.ItemArray[0], (r1, r2) => new { r1, r2 })
                      .ToList()
                      .ForEach(i => i.r1.SetField(1, i.r2.ItemArray[1]));
          }
        }
        ItemsAdapter.Update(ItemsTable);
