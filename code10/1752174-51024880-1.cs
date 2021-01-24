        /// <summary>
        /// Move a csv file column to a new position. File is modified in place.
        /// </summary>
        public void MoveCsvColumn(string file, int column, int position, string delimeter = ",")
        {
            using (var reader = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Write)))
            using (var writer = new StreamWriter(new FileStream(file, FileMode.Open, FileAccess.Write, FileShare.Read)))
            {
                while (!reader.EndOfStream)
                {
                    // Read the line
                    var line = reader.ReadLine().Split(new string[] { delimeter }, StringSplitOptions.None);
                    // Move the column within the array of columns
                    MoveColumn(line, column, position);
                    // write the output
                    writer.WriteLine(string.Join(delimeter, line));
                }
            }
        }
        /// <summary>
        /// Move a column within the array to the new destination
        /// </summary>
        public void MoveColumn(object[] line, int from, int to)
        {
            to = Math.Max(0, Math.Min(line.Length - 1, to));
            if (from == to 
                || from < 0 
                || from >= line.Length)
            {
                return;
            }
            while (from != to)
            {
                if (from > to)
                {
                    // percolate down
                    Swap(line, from, from-1);
                    from--;
                }
                else
                {
                    // percolate up
                    Swap(line, from, from + 1);
                    from++;
                }
            }
        }
        /// <summary>
        /// Swap values positions within the array
        /// </summary>
        public void Swap(object[] line, int a, int b)
        {
            var tmp = line[a];
            line[a] = line[b];
            line[b] = tmp;
        }
