    public class LogEvent
    {
        /* This is the event code you reference from your code 
         * so you're not working with magic numbers.  It will work
         * much like an enum */
        public string Code; 
    
        /* This is the event id that's published to the event log
         * to allow simple filtering for specific events */
        public int Id; 
    
        /* This is a predefined string format that allows insertion
         * of variables so you can have a descriptive text template. */
        public string DisplayFormat;
        /* A constructor to allow you to add items to a collection in
         * a single line of code */
        public LogEvent(int id, string code, string displayFormat)
        {
            Code = code;
            Id = id;
            DisplayFormat = displayFormat;
        }
        public LogEvent(int id, string code)
            : this(id, code, null)
        {
        }
        public LogEvent()
        {
        }
    }
