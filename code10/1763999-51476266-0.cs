    FormEmbedded formGuest;
    private void button1_Click(object sender, EventArgs e)
    {
        formGuest = new FormEmbedded();
        formGuest.TopLevel = false;
        formGuest.Parent = panelContainer;
        formGuest.Location = new Point(4, 4);
        formGuest.FormBorderStyle = FormBorderStyle.None; ;
        formGuest.Show();
    }
    private void buttonShrink_Click(object sender, EventArgs e)
    {
        //Maybe insert a classic dotted mini-button to re-inflate the sidebar if needed
        panelSideBar.Width = 6;
    }
    private void panelContainer_Resize(object sender, EventArgs e)
    {
        Rectangle rect = panelContainer.ClientRectangle;
        rect.Inflate(-3, -3);
        formGuest.Size = rect.Size;
    }
