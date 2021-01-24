    public List<DataElement> Summarize(IEnumerable<DataElement> data, int range)
    {
    	return data.GroupBy(de => Math.Floor(de.Mass / range) * range,
    					   (groupKey, g) => new DataElement
    					   {
    						   Mass = groupKey,
    						   Intensity = g.Sum(d => d.Intensity)
    					   })
    				.OrderBy(de => de.Mass)
                    .ToList();
    }
