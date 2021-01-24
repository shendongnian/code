         public ActionResult PercentageDistributionFault()
                {
                    // Get data to use in Chart
                    var model = new BasicChart1();
                    var data = db.RequestMalfunctionTypes.GroupBy(x => x.MalfunctionTypeID).Select(x => new NameCountClass
                    {
                        Name = x.FirstOrDefault().MalfunctionType.Name,
                        Count = x.Count()
                    }).OrderBy(x => x.Count).ToList();
        
                    model.Data.AddRange(data);
        
                    foreach (var item in data)
                    {
                        model.XData.Add(item.Name);
                        model.YDataINT.Add(item.Count);
                    }
                    // Create chart object and pass it to View
                    var chart = new Chart(1200, 800, GetMyCustomTheme())
                       .AddTitle("Mega chart")
                       .AddSeries("Default",
                                   chartType: "bar",
                                  xValue: model.XData, xField: "Name",
                                  yValues: model.YDataINT, yFields: "Value");
        
                    return View(chart);
                }
    
    private string GetMyCustomTheme()
            {
                return @"
                <Chart BackColor=""White"" BackGradientStyle=""TopBottom"" BorderColor=""181, 64, 1"" 
                   BorderWidth=""2"" BorderlineDashStyle=""Solid"" Palette=""SemiTransparent"" 
                   AntiAliasing=""All"">
                  
                   <ChartAreas>
                      <ChartArea Name=""Default"" _Template_=""All"" BackGradientStyle=""None""
                         BackColor=""White"" BackSecondaryColor=""White"" 
                         BorderColor=""64, 64, 64, 64"" BorderDashStyle=""Solid"" 
                         ShadowColor=""Transparent"">                      
                         
                         <AxisX Title=""Countries"" IsLabelAutoFit=""True"">
                            <LabelStyle Angle = ""-90"" Interval = ""1"" />   
                         </AxisX>
                         
                         <Area3DStyle Enable3D=""False"" Inclination=""60"" Rotation=""45""/>
                      </ChartArea>
                   </ChartAreas>
                </Chart>";
            }
