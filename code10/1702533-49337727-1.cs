    private void btnClick2_Click(object sender, RoutedEventArgs e)
            {
        string dateString1, dateString2, format;
        CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime t = DateTime.Parse(datePicker1.Text);
                DateTime End = DateTime.Parse(datePicker2.Text);
                DateTime g = t.AddDays(6);
                TimeSpan ts = (g - t);
    
                for (DateTime i = t; i <= End; i += ts)
                {
                    DateTime r = i.AddDays(2);    
                    dateString1 = i.ToString("MM/dd/yyyy");
                    dateString2 = r.ToString("MM/dd/yyyy");
                    format = "d";
                    DateTime a = DateTime.ParseExact(dateString1, format, provider);
                    DateTime b = DateTime.ParseExact(dateString2, format, provider);
                    myCalendar.SelectedDates.AddRange(a, b);
                }
            }
