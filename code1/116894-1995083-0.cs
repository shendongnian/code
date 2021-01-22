    public class DynamicDataGridBuilder<TContext, TEntity> where TEntity : EntityObject
    {
        readonly MetaModel model = new MetaModel();
        public DynamicDataGridBuilder()
        {            
            model.RegisterContext(typeof(TContext), new ContextConfiguration { ScaffoldAllTables = true });
        }
        public void BuildColumns(DataGrid targetGrid)
        {
            MetaTable metaTable = model.GetTable(typeof(TEntity));
            // Decision whether to auto-generated columns still rests with the caller.
            targetGrid.Columns.Clear();
            foreach (var metaColumn in metaTable.Columns.Where(x => x.GetType().Name == "MetaColumn" && x.Scaffold))      
            {
                switch (metaColumn.ColumnType.Name)
                {
                    case "Boolean":
                        targetGrid.Columns.Add(new DataGridCheckBoxColumn { Binding = new Binding(metaColumn.Name), Header = metaColumn.DisplayName });
                        break;
                    default:
                        targetGrid.Columns.Add(new DynamicDataGridTextColumn { MetaColumn = metaColumn, Binding = new Binding(metaColumn.Name), Header = metaColumn.DisplayName });
                        break;
                }
            }
        }
    }
