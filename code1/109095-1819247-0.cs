    // bind the grid but hide column 6
    this.grid.DataSource = this.entityModel.Entities;
    this.grid.Columns[6].Visible = false;
    // if there is any state then show column 6
    foreach (BrowserEntity _browseEntity in this.entityModel.Entities)
    {
         if (_browseEntity.State != null)
         {
             this.grid.Columns[6].Visible = true;
             break;
         }
    }
