    void Start()
    {
        HideAndShowButtons();
    }
    void HideAndShowButtons()
    {
        object1.gameObject.SetActive(PlayerPrefs.GetInt("HiddenButton") != 1);
        object2.gameObject.SetActive(PlayerPrefs.GetInt("HiddenButton") != 2);
    }
    public void whenclickbutton1()
    {
        PlayerPrefs.SetInt("HiddenButton", 1);
        PlayerPrefs.Save();
        HideAndShowButtons();
    }
    public void whenclickbutton2()
    {
        PlayerPrefs.SetInt("HiddenButton", 2);
        PlayerPrefs.Save();
        HideAndShowButtons();
    }
