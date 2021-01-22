    var resman = ViewModelResources.TimeFrame.ResourceManager;
    ViewBag.TimeFrames = from MapOverlayTimeFrames timeFrame in Enum.GetValues(typeof (MapOverlayTimeFrames))
                            select new SelectListItem
                                {
                                    Value = timeFrame.ToString(),
                                    Text = resman.GetString(timeFrame.ToString()) ?? timeFrame.ToString()
                                };
