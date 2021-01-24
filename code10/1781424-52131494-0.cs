    public GameObject panel; // drop the panel in the editor
    public void onAdvancedClicked()
    {
       panel.SetActive(!panel.activeSelf); // make it active/inactive with one click
    }
