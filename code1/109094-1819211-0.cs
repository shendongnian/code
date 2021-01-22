    bool isColumnVisible = false;
    this.grid.DataSource = this.entityModel.Entities;
    foreach (BrowserEntity _browseEntity in this.entityModel.Entities)
    {
                if (_browseEntity.State != null && this.entityModel.Entities.Count>0)
                {
                    isColumnVisible = true;
                    break;
                }
    }
    this.grid.Columns[6].Visible = isColumnVisible;
