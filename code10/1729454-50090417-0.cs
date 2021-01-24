    public void setPanel(Panel newPanel)
    {
        newPanel.BackgroundImage = piecePanel.BackgroundImage;
        piecePanel.BackgroundImage = null;
        piecePanel = newPanel;
    }
