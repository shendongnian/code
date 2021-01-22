    public class DateTimeQuestion : Question
    {
        public IAnswer MakeAnswer(string value)
        {
            //  Ignoring error handling here
            return new DateTimeAnswer(this, DateTime.Parse(value));
        }
    }
