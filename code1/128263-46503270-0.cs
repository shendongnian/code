    public class StringBuilderEx
    {
        List<string> data = new List<string>();
        public void Append(string input)
        {
            data.Add(input);
        }
        public void AppendLine(string input)
        {
            data.Add(input + "\n");
        }
        public void AppendLine()
        {
            data.Add("\n");
        }
        /// <summary>
        /// Copies all data to a String.
        /// Warning: Will fail with an OutOfMemoryException if the data is too
        /// large to fit into a single contiguous string.
        /// </summary>
        public override string ToString()
        {
            return String.Join("", data);
        }
        /// <summary>
        /// Process Each section of the data in place.   This avoids the
        /// memory pressure of exporting everything to another contiguous
        /// block of memory before processing.
        /// </summary>
        public void ForEach(Action<string> processData)
        {
            foreach (string item in data)
                processData(item);
        }
    }
