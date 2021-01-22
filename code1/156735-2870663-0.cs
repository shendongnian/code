    Binding b = new Binding("Text", BindingSourceInstance, "data.DateCreated");
    b.Parse += new EventHandler(b_Parse);
    b.Format += new EventHandler(b_Format);
    private void b_Format(object sender, ConvertEventArgs e) {
        if (e.DesiredType != typeof(DateTime)) return;
        e.Value.ToString("dd/MM/yyyy");
        // Or you may prefer some other variants:
        // e.Value.ToShortDateString();
        // e.Value.ToLongDateString();
        // e.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture.DateTimeInfo.ShortDatePattern);
    }
    private void b_Parse(object sender, ConvertEventArgs e) {
        // Choose whether you to handle perhaps bad input formats...
        e.Value = DateTime.Parse(e.Value, CultureInfo.InvariantCulture); // The CultureInfo here may be whatever you choose.
    }
