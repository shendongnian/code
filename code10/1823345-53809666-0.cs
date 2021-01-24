    private void SelectedItemChangedHandler()
    {
        var item = LstStoreItems.SelectedItem;
        if (item is Weapon) SetLabelsFor(item as Weapon);
        else if (item is Shield) SetLabelsFor(item as Shield);
        else if (item is Armor) SetLabelsFor(item as Armor);
        else ClearLabels();
    }
    private void SetLabelsFor(Weapon weapon)
    {
        label1.Text = weapon.Name;
        // etc.
    }
    private void SetLabelsFor(Shield shield)
    {
        label1.Text = shield.Name;
        // etc.
    }
    private void SetLabelsFor(Armor armor)
    {
        label1.Text = armor.Name;
        // etc.
    }
