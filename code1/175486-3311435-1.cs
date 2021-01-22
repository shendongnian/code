    public static class ControllerExtensions
    {
        public static ActionResult Csv<T>(this Controller controller, IEnumerable<T> records)
        {
            return new CsvResult<T>(records);
        }
    }
