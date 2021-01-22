    public Dictionary<int, string> GetFileInfo(Exception ex, int linesBefore, int linesAfter)
        {
            Dictionary<int, string> sb = new Dictionary<int, string>();
            var st = new System.Diagnostics.StackTrace(ex, true);
            var frame = st.GetFrame(0);
            using (System.IO.StreamReader file = new System.IO.StreamReader(frame.GetFileName()))
            {
                if (file == null)
                    return sb;
                int counter = 0;
                int line = frame.GetFileLineNumber();
                int lastline =  line + linesAfter;
                int firstline = line - linesBefore;
                while (!file.EndOfStream && counter < lastline)
                {
                    string str = file.ReadLine();
                    if (counter > firstline && !string.IsNullOrWhiteSpace(str))
                        sb.Add(counter, str);
                    counter++;
                }
            }
            return sb;
        }
