     response.Data.Detectors = atisDAO.GetPME(xl, null).Select(pme =>
                    new DetectorDetails{
                                        ID = pme.PlaceNum.ToString(),
                                        Count = atisDAO.GetSummaryEntries(int.Parse(pme.PlaceNum.ToString())).Count(), //some work needed here to ensure pme.PlaceNum is actually an number 
                                        DetectionTime = new DateTimeZone{
                                            ReadDate = summaries.Max(summary => summary.ReadDate).ToString(DATE_FORMAT),
                                            ReadTime = summaries.Max(summary => summary.ReadDate).ToString(TIME_FORMAT)
                                        }
                                      }
     );
