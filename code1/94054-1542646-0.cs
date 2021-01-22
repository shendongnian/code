            foreach (Excel.ChartObject chart in (Excel.ChartObjects)sheet.ChartObjects(Type.Missing))
            {
                IDictionary<int, Boolean> colHasValues = new Dictionary<int, Boolean>(); 
                ArrayList seriesFormulas = new ArrayList(); 
                
                foreach (Excel.Series series in (Excel.SeriesCollection)chart.Chart.SeriesCollection(Type.Missing))
                {
                    seriesFormulas.Add(series.Formula);
                    Array sValues = (Array)series.Values;
                    int i = 1;
                    foreach (Object o in sValues)
                    {
                        if(!colHasValues.Keys.Contains(i)) colHasValues.Add(i, false);                        
                        if (o != null)
                        {
                            colHasValues[i] = true;                             
                        }
                        i++;
                    }
                }
                if (!colHasValues.Values.Contains(true))
                {   
                    chart.Delete();
                }
                else if (colHasValues.Values.Contains(false) && seriesFormulas.Count > 1)
                {    
                    
                    ArrayList newSeriesFormulas = new ArrayList(); 
                    
                    foreach (String formula in seriesFormulas)
                    {
                        
                        String[] formulaBits = formula.Split(";".ToCharArray());
                        if (formulaBits.Length == 4)
                        { 
                            for (int arrNr = 1; arrNr <= 2; arrNr++)
                            {   //1 = XValues, 2 = Values
                                int indexFirstChar = formulaBits[arrNr].IndexOf(':');
                                int indexLastChar = formulaBits[arrNr].LastIndexOf('$', indexFirstChar) + 1;
                                String firstRow = formulaBits[arrNr].Substring(indexLastChar, indexFirstChar - indexLastChar);
                                String firstColumn = formulaBits[arrNr].Substring(indexLastChar - 2, 1);
                                formulaBits[arrNr] = "";
                                
                                foreach (KeyValuePair<int, Boolean> cat in colHasValues)
                                {
                                    if (cat.Value == true)
                                    {
                                        formulaBits[arrNr] += "overzichten!$" + getExcelColumnName((getExcelColumnNumber(firstColumn) + cat.Key - 1)) + "$" + firstRow + ":$" + getExcelColumnName((getExcelColumnNumber(firstColumn) + cat.Key - 1)) + "$" + firstRow + ";";
                                    }
                                }
                                formulaBits[arrNr] = formulaBits[arrNr].TrimEnd(";".ToCharArray());
                                if (formulaBits[arrNr].Contains(';')) 
                                {
                                    formulaBits[arrNr] = "(" + formulaBits[arrNr] + ")";
                                }
                            }
                            newSeriesFormulas.Add(String.Join(";", formulaBits));
                        }
                    }
                    int seriesid = 0;
                    foreach (Excel.Series series in (Excel.SeriesCollection)chart.Chart.SeriesCollection(Type.Missing))
                    {
                        series.Formula = newSeriesFormulas[seriesid].ToString();
                        seriesid++;
                    }
                }
                
            }
