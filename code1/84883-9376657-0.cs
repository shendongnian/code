    private string FormatResult(string vResult)
        {
            string output;
            string input = vResult;
            // unify string (no spaces, only . ) 
            output = input.Trim().Replace(" ", "").Replace(",", ".");
            // split it on points 
            string[] split = output.Split('.');
            if (split.Count() > 1)
            {
                // take all parts except last 
                output = string.Join("", split.Take(split.Count() - 1).ToArray());
                // combine token parts with last part 
                output = string.Format("{0}.{1}", output, split.Last());
            }
            string sfirst = output.Substring(0, 1);
            try
            {
                if (sfirst == "<" || sfirst == ">")
                {
                    output = output.Replace(sfirst, "");
                    double res = Double.Parse(output);
                    return String.Format("{1}{0:0.####}", res, sfirst);
                }
                else
                {
                    double res = Double.Parse(output);
                    return String.Format("{0:0.####}", res);
                }
            }
            catch
            {
                return output;
            }
        }
