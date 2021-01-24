    //Define here the Form which will be embedded
    [Your Form Class] EmbeddedForm;
    private void button1_Click(object sender, EventArgs e)
    {
        EmbeddedForm = new [Your Form Class]() {
            TopLevel = false,
            Parent = panContainer,
            Location = new Point(4, 4),
            Enabled = true
        };
        EmbeddedForm.Show();
    }
    private void buttonShrink_Click(object sender, EventArgs e)
    {
        //Maybe insert a classic dotted mini-button to re-inflate the sidebar when needed
        panelSideBar.Width = 6;
    }
    private void panelContainer_Resize(object sender, EventArgs e)
    {
        Rectangle rect = panelContainer.ClientRectangle;
        rect.Inflate(-3, -3);
        EmbeddedForm.Size = rect.Size;
    }
