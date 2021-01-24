    interface ICellCheck
    {
        // I'm guessing these classes should check the cells of something,
        // but this interface should hold Whatever the different 
        // CellCheck implementations have is common
        bool CheckCell();
    }
    
    class DateCellCheck : ICellCheck
    {
        public bool CheckCell()
        {
            // implementation here
        }
    }
    
    class TeamCellCheck : ICellCheck
    {
        public bool CheckCell()
        {
            // implementation here
        }
    }
        
    class ValueCellCheck : ICellCheck
    {
        public float? MinValue { get; set; }
        public float? MaxValue { get; set; }    
        
        public bool CheckCell()
        {
            // implementation here
        }
    }
    
    class TextCellCheck : ICellCheck
    {
        public bool TextCaseSensitive { get; set; }
        public string Text { get; set; }    
        
        public bool CheckCell()
        {
            // implementation here
        }
    }
    
    
