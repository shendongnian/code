        public class MyJsonTextReader : JsonTextReader
        {
            public MyJsonTextReader(TextReader textReader) : base(textReader)
            {
                SupportMultipleContent = true;
            }
            public bool ObjectDone()
            {
                base.SetStateBasedOnCurrent();
                try
                {
                    // This call works fine at the end of the file but may throw JsonReaderException
                    // if some bad character follows our JSON object
                    return !base.Read();
                }
                catch (JsonReaderException)
                {
                    return true;
                }
            }
        }
