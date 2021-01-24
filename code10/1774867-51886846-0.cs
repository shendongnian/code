      if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    Chart senderChart = (Chart)sender;
                    var series = senderChart.Series;
                    var points = e.HitTestResult.Series.Points;
    
                    //e.HitTestResult.Series.
                    var legendTip = series.Select(x => new
                    {
                        x.LegendToolTip,
                        x.Name
                    }).ToList();
    
                    List<TooltipTextModel> tooltipModel = new List<TooltipTextModel>();
                    foreach (var lt in legendTip)
                    {
                    TooltipTextModel assignTooltip = new TooltipTextModel();
                        var finalString = lt.LegendToolTip.Replace("\r", "");
                        string[] tooltipstring = finalString.Split('\n');
    
                        var progresstoBackCheckString = string.Join("\n", tooltipstring.Where(x => x.Contains("progress to backcheck")));
                        var backcheckToCorrectionsString = string.Join("\n", tooltipstring.Where(x => x.Contains("backcheck to corrections")));
                        var correctionsToCompletedString = string.Join("\n", tooltipstring.Where(x => x.Contains("corrections to completed")));
                        var progressToCompletedString = string.Join("\n", tooltipstring.Where(x => x.Contains("progress to completed")));
    
                        assignTooltip.ProgresstoBackCheckString = progresstoBackCheckString;
                        assignTooltip.BackcheckToCorrectionsString = backcheckToCorrectionsString;
                        assignTooltip.CorrectionsToCompletedString = correctionsToCompletedString;
                        assignTooltip.ProgressToCompletedString = progressToCompletedString;
                        assignTooltip.SerieName = lt.Name;
                        tooltipModel.Add(assignTooltip);
                        }
    
                    var hitSerie = e.HitTestResult.Series.Name.ToString();
    
                    foreach (var tt in tooltipModel.Where(x=>x.SerieName == hitSerie))
                    {
                        int i = e.HitTestResult.PointIndex;
                        var chartSerie = empChart.Series[e.HitTestResult.Series.Name].Name.ToString();
                      
                            DataPoint dp = e.HitTestResult.Series.Points[i];
    
                            switch (dp.AxisLabel)
                            {
                                case "Progress to Back Check":
                                    e.Text = $"{tt.ProgresstoBackCheckString}";
                                    break;
                                case "Back Check to Corrections":
                                    e.Text = $"{tt.BackcheckToCorrectionsString}";
                                    break;
                                case "Corrections to Completed":
                                    e.Text = $"{tt.CorrectionsToCompletedString}";
                                    break;
                                case "Progress to Completed":
                                    e.Text = $"{tt.ProgressToCompletedString}";
                                    break;
                        }
                    }
                }
