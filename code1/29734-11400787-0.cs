    DateTime d = DateTime.Now;
    for (int i = 0; i < 10000; i++)
    {
        Action();
    }
    MessageBox.Show((DateTime.Now - d).TotalMilliseconds.ToString());
