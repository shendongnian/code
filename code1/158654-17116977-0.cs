           get
            {
                var list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Text = "Select Month", Value = "0" });
                list.AddRange(DateTimeFormatInfo
                      .InvariantInfo
                      .MonthNames
                      .Where(m => !String.IsNullOrEmpty(m))
                      .Select((monthName, index) => new SelectListItem
                      {
                          Value = (index + 1).ToString(),
                          Text = monthName
                      }).ToList());
                return list;
            }
