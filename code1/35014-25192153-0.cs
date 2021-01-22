    private void HideAllTabsOnTabControl(TabControl theTabControl)
    {
      theTabControl.Appearance = TabAppearance.FlatButtons;
      theTabControl.ItemSize = new Size(0, 1);
      theTabControl.SizeMode = TabSizeMode.Fixed;
    }
