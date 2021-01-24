    List<Label> underline = new List<Label>();
    int left = 300;
    int top = 275;
    
    for (int i = 0; i < data.solution.Length; i++) //data is the object that contains the word that is the solution
    {
        underline.Add(new Label());
        underline[i].Parent = this;
        underline[i].Text = "_";
        underline[i].Size = new Size(35, 35);
        underline[i].Location = new Point(left, top);
        left += 30;
        underline[i].Font = new Font(new FontFamily("Microsoft Sans Serif"), 20, FontStyle.Bold);
    }
