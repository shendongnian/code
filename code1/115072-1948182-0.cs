    static IList<KeyValuePair<string, DayOfWeek>> GetDayOfWeekBindingList()
    {
        List<KeyValuePair<string, DayOfWeek>> dayOfWeekList = new List<KeyValuePair<string, DayOfWeek>>();
        foreach (int day in Enum.GetValues(typeof(DayOfWeek)))
        {
            string dayName = CultureInfo.CurrentCulture.DateTimeFormat.DayNames[day];
            dayOfWeekList.Add(new KeyValuePair<string, DayOfWeek>(dayName, (DayOfWeek)day));
        }
        return dayOfWeekList;
    }
    private void BindDayOfWeekComboBox()
    {
        dayOfWeekComboBox.DisplayMember = "Key";
        dayOfWeekComboBox.ValueMember = "Value";
        dayOfWeekComboBox.DataSource = GetDayOfWeekBindingList();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        BindDayOfWeekComboBox();
        ...
    }
