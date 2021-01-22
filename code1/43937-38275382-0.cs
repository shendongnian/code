     var list = (your generic list).Select(i => new { i.idnfe, i.ide.cnf }).ToArray(); 
                
     if (list .Length > 0) {
          grid1.AutoGenerateColumns = false;
          grid1.ColumnCount = 2;
                   
          grid1.Columns[0].Name = "Id";
          grid1.Columns[0].DataPropertyName = "idnfe";
          grid1.Columns[1].Name = "NumNfe";
          grid1.Columns[1].DataPropertyName = "cnf";
          grid1.DataSource = lista;
          grid1.Refresh();
    }
