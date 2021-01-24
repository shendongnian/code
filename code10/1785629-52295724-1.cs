    bool Do = true;
    int i = 0;
    Form2 F = new Form2();
    while (Do)
    {
        try
        {
            F.AddItem(listView1.Columns[i].Name);
            i++;
        }
        catch
        {
            Do = false;
        }
    }
