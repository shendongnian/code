     DataColumnCollection colunas = tabela.Columns;
     foreach (DataRow linha in tabela.Rows)
     {
           this.AddRow();
           foreach (DataColumn coluna in colunas)
           {
               this[coluna.ColumnName] = linha[coluna];
           }
      }
      this.ExportToFile(path);
}`
       
