    public static void FormatDate(MaskedTextBox c) {
        c.DataBindings[0].Format += new ConvertEventHandler(Date_Format);
        c.DataBindings[0].Parse += new ConvertEventHandler(Date_Parse);
    }
    private static void Date_Format(object sender, ConvertEventArgs e) {
        if (e.Value == null)
            e.Value = "";
        else
            e.Value = ((DateTime)e.Value).ToString("MM/dd/yyyy");
    }
    static void Date_Parse(object sender, ConvertEventArgs e) {
        if (e.Value.ToString() == "  /  /")
            e.Value = null;
    }
