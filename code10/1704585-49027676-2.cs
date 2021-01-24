    private void Form1_Load(object sender, EventArgs e)
    {
        TextAndButtonControl bcol = new TextAndButtonControl();
        bcol.Text = "Button Column ";
        bcol.ButtonText = "Click Me";
        bcol.Name = "btnClickMe";
        bcol.RenderControl();
        dgMainGrid.Controls.Add(bcol);
    }
