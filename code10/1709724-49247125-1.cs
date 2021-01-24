    class TableData
    {
        public List<Catgeory> Categories { get; set; }       
        public List<Boards> Boards { get; set; }
    }
    public async Task<TableData> GetTableDataAsync(AdminBundle abundleList)
    {
        return new TableData
        {
            Categories = await FetchCategoriesAsync(abundleList),            
            Boards = await FetchBoardsAsync(abundleList);
        };
    }
