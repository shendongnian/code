    using System.Text.RegularExpressions;
    static void Main(string[] args)
    {
        string[] formulas = { "Z1", "ZZ1", "AZ1", "AZB1", "BZZ2",
                            "=SUM($B$99:B99)","=SUM($F99:F99)", "=(SUM($B$0:B0)/SUM(1!$B$11:22!B33) -1)",
                            "=SUM(X80:Z1)", "=A0 + B1 - C2 + Z5", "=C0+ B1",
                            "=$B$0+ AC1", "=AA12-ZZ34 + AZ1 - BZ2 - BX3 + BZX4",
                            "=SUMX2MY2(A2:A8,B2:B8)",   // ensure function SUMX2MY2 isn't mistakenly incremented
                            "=$B$40 + 50 - 20"          // no match
                            //,"Check out T4 generation!"  // not a formula but it'll still increment T4, use formula.StartsWith("=")
                            };
    
        // use this if you don't want to include regex comments
        //Regex rxCell = new Regex(@"(?<![$])\b(?<col>[A-Z]+)(?<row>\d+)\b");
    
        // regex comments in this style requires RegexOptions.IgnorePatternWhitespace
        string rxCellPattern = @"(?<![$])       # match if prefix is absent: $ symbol (prevents matching $A1 type of cells)
                                                # (if all you have is $A$1 type of references, and not $A1 types, this negative look-behind isn't needed)
                                \b              # word boundary (prevents matching Excel functions with a similar pattern to a cell)
                                (?<col>[A-Z]+)  # named capture group, match uppercase letter at least once
                                                # (change to [A-Za-z] if you have lowercase cells)
                                (?<row>\d+)     # named capture group, match a number at least once
                                \b              # word boundary
                                ";
        Regex rxCell = new Regex(rxCellPattern, RegexOptions.IgnorePatternWhitespace);
    
        foreach (string formula in formulas)
        {
            if (rxCell.IsMatch(formula))
            {
                Console.WriteLine("Formula: {0}", formula);
                foreach (Match cell in rxCell.Matches(formula))
                    Console.WriteLine("Cell: {0}, Col: {1}", cell.Value, cell.Groups["col"].Value);
    
                // the magic happens here
                string newFormula = rxCell.Replace(formula, IncrementColumn);
                Console.WriteLine("Modified: {0}", newFormula);
            }
            else
            {
                Console.WriteLine("Not a match: {0}", formula);
            }
            Console.WriteLine();
        }
    }
    private static string IncrementColumn(Match m)
    {
        string col = m.Groups["col"].Value;
        char c;
    
        // single character column name (ie. A1)
        if (col.Length == 1)
        {
            c = Convert.ToChar(col);
            if (c == 'Z')
            {
                // roll over
                col = "AA";
            }
            else
            {
                // advance to next char
                c = (char)((int)c + 1);
                col = c.ToString();
            }
        }
        else
        {
            // multi-character column name (ie. AB1)
            // in this case work backwards to do some column name "arithmetic"
            c = Convert.ToChar(col.Substring(col.Length - 1, 1));   // grab last letter of col
    
            if (c == 'Z')
            {
                string temp = "";
                for (int i = col.Length - 1; i >= 0; i--)
                {
                    // roll over should occur
                    if (col[i] == 'Z')
                    {
                        // prepend AA if current char is not the last char in column and its next neighbor was also a Z
                        // ie. column BZZ: if current char is 1st Z, it's neighbor Z (2nd Z) just got incremented, so 1st Z becomes AA
                        if (i != col.Length - 1 && col[i + 1] == 'Z')
                        {
                            temp = "AA" + temp;
                        }
                        else
                        {
                            // last char in column is Z, becomes A (this will happen first, before the above if branch ever happens)
                            temp = "A" + temp;
                        }
                    }
                    else
                    {
                        temp = ((char)((int)col[i] + 1)).ToString() + temp;
                    }
                }
                col = temp;
            }
            else
            {
                // advance char
                c = (char)((int)c + 1);
                // chop off final char in original column, append advanced char
                col = col.Remove(col.Length - 1) + c.ToString();
            }
        }
    
        // updated column and original row (from regex match)
        return col + m.Groups["row"].Value;
    }
