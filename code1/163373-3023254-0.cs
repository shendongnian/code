        string time = "0800";
        DateTime dt = DateTime.ParseExact(string.Format("{0}:{1}", time.Substring(0, 2), time.Substring(2, 2)), "HH:mm", CultureInfo.InvariantCulture);
        MessageBox.Show(string.Format("{0:h:mm tt}", dt));
        time = "2345";
        dt = DateTime.ParseExact(string.Format("{0}:{1}", time.Substring(0, 2), time.Substring(2, 2)), "HH:mm", CultureInfo.InvariantCulture);
        MessageBox.Show(string.Format("{0:h:mm tt}", dt));
