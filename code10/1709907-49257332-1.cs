        ...
        Match t = regexTID.Match(line);
        if (t.Success)
        {
            //TIDwriter.WriteLine(TID);
            TID = t.Value;
            if (!TIDdict.ContainsKey(TID))
            {
                TIDdict.Add(TID, new List<long>());
            }
            TIDdict[TID].Add(position);
            MatchCollection matches = Regex.Matches(line, @"\d{2}:\d{2}:\d{2}\.\d{4}");
            // Use foreach-loop.
            foreach (Match m in matches)
            {
                foreach (Capture capture in m.Captures)
                {
                     var dt = new DateTime();
                     if (DateTime.TryParseExact(capture.Value, "HH:mm:ss.ffff", null, DateTimeStyles.None, out dt))
                     {
                         if ((dt - previousDt).TotalSeconds > 1)
                         {
                             counterTimeout++;
                             writer.WriteLine(previousLine);
                             writer.WriteLine(line + Environment.NewLine);
                             TupleList.Add(new Tuple<long, long, string>(previousPosition, position, TID));
                         }
                         previousLine = line;
                         previousDt = dt;
                         previousPosition = position;
                     }   
                }
            }
        }
        ... 
