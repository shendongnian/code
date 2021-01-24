     public override void OnApplyTemplate()
     {
         base.OnApplyTemplate();
         if (!AutoGenerateColumns)
         {
             var grid = GetTemplateChild("PART_Grid") as DataGrid;
             foreach (var column in _gridColumns)
                 grid.Columns.Add(column);
         }
     }
