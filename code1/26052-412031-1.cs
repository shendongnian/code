    this.Hide();
    var t = new System.Windows.Forms.Timer
    {
        Interval = 3000 // however long you want to hide for
    };
    t.Tick += (x, y) => { t.Enabled = false; this.Show(); };
    t.Enabled = true;
