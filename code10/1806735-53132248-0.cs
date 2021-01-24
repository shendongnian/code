     public List<TimeSerie> GetTimeSeries()
                {
                    List<TimeSerie> ret = new List<TimeSerie>();
    
                    if(a.ListData.Count != 0)
                    {
                        ret.Add(a);
    
                        foreach(var data in a.ListData)
                        {
                            GetRec(data, ref ret);
                        }
                    }
    
                    return ret;
                }
    
                private void GetRec(Data data, ref List<TimeSerie> ret)
                {
                    if(data.A != null && data.A.ListData.Count != 0)
                    {
                        ret.Add(data.A);
                        foreach(var d in data.A.ListData)
                        {
                            GetRec(d, ref ret);
                        }
                    }   
                }
