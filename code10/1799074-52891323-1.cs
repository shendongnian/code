    public List<GoogleDataDto> Filter(GetReportsResponse response)
        {
            if (response == null) return null;
            List<GoogleDataDto> gData = new List<GoogleDataDto>();
            foreach (var report in response.Reports)
            {
                foreach (var row in report.Data.Rows)
                {
                    GoogleDataDto dto = new GoogleDataDto();
                    
                    foreach (var metric in row.Metrics)
                    {
                        int index = 0; // Index counter, used to get the metric name
                        foreach (var value in metric.Values)
                        {
                            var metricHeader = report.ColumnHeader.MetricHeader.MetricHeaderEntries[index];
                            //Sets property value based on the metric name
                            dto.SetMetricValue(metricHeader.Name, value);
                            index++;
                        }
                    }
                    
                    int dIndex = 0; // Used to get dimension name
                    foreach (var dimension in row.Dimensions)
                    {
                        var dimensionName = report.ColumnHeader.Dimensions[dIndex];
                        //Sets property value based on dimension name
                        dto.SetDimensionValue(dimensionName, dimension);
                        dIndex++;
                    }
                    // Will only add the dto to the list if its not a duplicate
                    if (!gData.IsDuplicate(dto))
                        gData.Add(dto);
                }
            }
            return gData;
        }
