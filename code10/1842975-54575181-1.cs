    double increment = Convert.ToDouble(resultTemp.Count) / targetItemsCount;
    List<short> result = Enumerable.Range(0, targetItemsCount).
                                    Select(x => resultTemp[(int)(x * increment)]).
                                    ToList();
                                    
