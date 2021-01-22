    public Dictionary<double, List<double>> Example()
            {
                String[] aSeparators = {"{", "},", ",", "}"};
                String data = "411:{1,2,3},843:{6,5,4,3,2,1},241:{4,1,2}";
                String[] bases = data.Split(aSeparators, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<double, List<double>> aDict = null;
    
                double aHeadValue = 0;
                List<Double> aList = null;
                foreach (var value in bases)
                {
                    if (value.EndsWith(":"))
                    {
                        if (aDict == null)
                            aDict = new Dictionary<double, List<double>>();
                        else
                            aDict.Add(aHeadValue, aList);
                        aHeadValue = Double.Parse(value.TrimEnd(':'));
                        aList = new List<Double>();
                    }
                    else
                    {
                        aList.Add(Double.Parse(value));
                    }
                }
                aDict.Add(aHeadValue, aList);
                return aDict;
            }
