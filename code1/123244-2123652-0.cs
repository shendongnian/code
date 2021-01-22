    List<Label> RpmList = new List<Label>();
    
    public void DoShit()
    {    
        RpmList.Add(label0x0);
        RpmList.Add(label0x1);
        RpmList.Add(label0x2);
        RpmList[0].BackColor = System.Drawing.Color.Yellow;
    }
    
    public void Form1_Load(object sender, EventArgs e)
    {
        DoShit();
        RpmList[1].BackColor = System.Drawing.Color.Yellow;    //    <---THIS ONE
    }
