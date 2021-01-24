    NodeChart NC = new NodeChart();
    private void Form1_Load(object sender, EventArgs e)
    {
        NC.theNodes.Add(new NetNode("A",""));
        NC.theNodes.Add(new NetNode("B","A"));
        NC.theNodes.Add(new NetNode("C","B"));
        NC.theNodes.Add(new NetNode("D","B"));
        NC.theNodes.Add(new NetNode("T","B"));
        NC.theNodes.Add(new NetNode("E","C"));
        NC.theNodes.Add(new NetNode("F","D,T"));
        NC.theNodes.Add(new NetNode("G","E,F"));
        NC.fillPrevNodes();
        NC.fillNextNodes();
        NC.layoutNodeX();
        NC.layoutNodeY();
        pictureBox1.Invalidate();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (NC.theNodes.Count <= 0) return;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        foreach (var n in NC.theNodes) n.draw(e.Graphics, 100, 33);
    }
