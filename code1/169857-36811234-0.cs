    RadCalendarDay holiday = new RadCalendarDay();
                        holiday.Date = Datetime.Now;//Your date which you want
                        holiday.IsSelectable = false;
                        holiday.IsDisabled = true;
                        holiday.ToolTip = "NOT AVAILABLE";
                        TableItemStyle style = new TableItemStyle();
                        style.BackColor = Color.HotPink;
                        holiday.ItemStyle.CopyFrom(style);
                        calendar1.SpecialDays.Add(holiday);
