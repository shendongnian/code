    public ActionResult ReadValue([DataSourceRequest] DataSourceRequest request, int sensorId){
            using (var db = new Entity())
            {
                var sensorValues = db.SensorValue.Where(sv => sv.SensorId == sensorId)
                    .Select(select => new ValueViewModel
                    {
                        ValueId = select.Id,
                        SensorId = select.SensorId,
                        Value = select.Value,
                        Comment = select.Comment,
                        Timestamp = select.Timestamp,
                        Category = new CategoryViewModel()
                        {
                            CategoryId = select.ValueCategory.Id,
                            CategoryName = select.ValueCategory.Name,
                            Unit = select.ValueCategory.Unit
                        },
                        EntryTimestamp = select.EntryTimestamp
                    }).OrderBy(order => order.Timestamp).ToList();
                for(int i=0; i< sensorValues.Count;i++)
                {
                    if(i>0)
                    {
                        sensorValues[i].ChangedValue = sensorValues[i].Value - sensorValues[i - 1].Value;
                    }
                    else
                    {
                        sensorValues[i].ChangedValue = 0;
                    }
                }
                return Json(sensorValues.ToDataSourceResult(request));
            }
        }
