    fa = new FormA();
    fa.TopLevel = false;
    fa.FormBorderStyle = FormBorderStyle.None;
    fa.Dock = DockStyle.Fill; 
    fb = new FormB();
    fb.panel1.Controls.Add(fa); // if panel1 was public
    fa.Show();
    fb.Show();
