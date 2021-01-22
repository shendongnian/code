    switch (cbDateFilter.Text)
                {
                    case "This Week":
                        dt = DateTime.Now;
                        while (dt.DayOfWeek != DayOfWeek.Monday) dt = dt.AddDays(-1); //find first day of week
                        dtFrom.Value = DateTime.Parse(dt.ToString("dd/MM/yyyy 00:00:00"));
                        dtTo.Value = DateTime.Parse(dt.AddDays(6).ToString("dd/MM/yyyy 23:59:59"));
                        break;
                    case "This Month":
                        dt = DateTime.Now;
                        while (dt.Day != 1) dt = dt.AddDays(-1); // find first day of month
                        dtFrom.Value = DateTime.Parse(dt.ToString("dd/MM/yyyy 00:00:00"));
                        dtTo.Value = DateTime.Parse(dt.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy 23:59:59"));
                        break;
                    case "This Quarter":
                        // if at end of Quarter then we need subtract -4 to get to priv Quarter
                        dt = DateTime.Now;
                        while (dt.Month != 7 &&
                            dt.Month != 10 &&
                            dt.Month != 1 &&
                            dt.Month != 4) dt = dt.AddMonths(-1); //find first month, fiscal year
                        while (dt.Day != 1) dt = dt.AddDays(-1); // find first day on month
                        dtFrom.Value = DateTime.Parse(dt.ToString("dd/MM/yyyy 00:00:00"));
                        dtTo.Value = DateTime.Parse(dt.AddMonths(3).AddDays(-1).ToString("dd/MM/yyyy 23:59:59"));
                        break;
