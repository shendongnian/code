    TimeSpan t;
    TimeSpan t2;
    TimeSpan.TryParse(label2.Text.Replace(" PM", ""), out t);
    TimeSpan.TryParse(label6.Text.Replace(" PM", ""), out t2);
    TimeSpan @new = t.Add(t2);
    label7.Text = @new.ToString();
