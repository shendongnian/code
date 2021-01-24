            string[] lines = File.ReadAllLines(Text, Encoding.GetEncoding(1257));
            int maxnbcol = 0;
            List<int> maxlgbycol = new List<int>();
            int[] maxpaddingbycol;
            List<string[]> stfile = new List<string[]>();
            //split each line and put the result in list<string[]>
            foreach (var line in lines)
            {
                var lineplitted = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (lineplitted.Length > maxnbcol) maxnbcol = lineplitted.Length;
                stfile.Add(lineplitted);
            }
            maxpaddingbycol = new int[maxnbcol];
            //calcul the max padding for each column
            for (int numline = 0; numline < stfile.Count; numline++)
            {
                for(int numcol = 0; numcol < stfile[numline].Length; numcol++)
                {
                    var lgword = stfile[numline][numcol].Length;
                    if (lgword > maxpaddingbycol[numcol])
                        maxpaddingbycol[numcol] = lgword;
                }
            }
            //apply padding and rebuild each line
            for (int numline = 0; numline < stfile.Count; numline++)
            {
                for (int numcol = 0; numcol < stfile[numline].Length; numcol++)
                    stfile[numline][numcol] = stfile[numline][numcol].PadRight(maxpaddingbycol[numcol]);
                var newline = String.Join(" ", stfile[numline]);
                Console.WriteLine(newline);// --> you could call your method to write an output file
            }
