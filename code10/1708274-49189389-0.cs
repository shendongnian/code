    private static void ReadCSVIntoDataTable()
            {
                foreach (String pathToSave in _pathToSave)
                {
                    var adapter = new GenericParsing.GenericParserAdapter(pathToSave, Encoding.UTF8);
                    adapter.FirstRowHasHeader = true;
    
                    DataTable dt = adapter.GetDataTable();
    
                    DataTableToExpose.Add(dt);
                }
            }
