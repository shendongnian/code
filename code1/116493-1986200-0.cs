    TextBox textBox = (TextBox)DatePicker.GetType().InvokeMember("dateTextBox",
        BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
        null, DatePicker, null);
    if (textBox != null)
    {
        DateTimeFormatInfo format = (new CultureInfo(DatePicker.Culture.Name)).DateTimeFormat;
        format.ShortDatePattern = DatePicker.DateFormat;
        DateTime date = DateTime.Parse(textBox.Text, format);
        Console.WriteLine(date.ToString());
    }
