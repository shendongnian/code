     public List<Dictionary<int, TimeSerie>> GetTimeSeries()
                {
                    var ret = new List<Dictionary<int, TimeSerie>>();
    
                    if(a.ListData.Count != 0)
                    {
    
                        foreach(var data in a.ListData)
                        {
                            GetRec(data, ref ret);
                        }
                    }
    
                    return ret;
                }
    
                private void GetRec(Data data, ref List<Dictionary<int, TimeSerie>> ret)
                {
                    if(data.A != null && data.A.ListData.Count != 0)
                    {
                        ret.Add(new Dictionary(data.id,data.A));
                        foreach(var d in data.A.ListData)
                        {
                            GetRec(d, ref ret);
                        }
                    }   
                }
