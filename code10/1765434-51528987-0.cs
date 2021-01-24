    interface IFileNameProvider
    {
        string GetFileName(string name);
        bool CanHandle(string name);
    } 
    class WordCsvFileNameProvider : IFileNameProvider
    {
        public string GetFileName(string name){
            return name.Split("_")[4];
        }
        public bool CanHandle(string name){
            return name.Contains(".doc") || name.Contains(".csv");
        }
    } 
    class TextExcelFileNameProvider : IFileNameProvider
    {
        public string GetFileName(string name){
            return name.Split(".")[3];
        }
        public bool CanHandle(string name){
            return name.Contains(".txt") || name.Contains(".xlsx");
        }
    } 
