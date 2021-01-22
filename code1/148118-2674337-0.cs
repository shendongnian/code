    public Form2()
    {
    }
    
    int index;
    public Form2(int index)
    {
        this.index = index;
    }
    
    // Code in Main Form
    Form2 f2 = new Form2(this.listView1.SelectedIndex);
    f2.ShowDialog();
