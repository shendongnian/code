    private void PopulateFamily()
    {
        var source = _mfgOrdersData
            .Select(o => o.ItemWrapper)
            .DistinctBy(o => new { o.ItemClass, o.Family })
            .OrderBy(f => f.CodeFamily)
            .ToList();
        FamilyFilterListBox.DataSource = source;
        FamilyFilterListBox.ValueMember = "Family";
        FamilyFilterListBox.DisplayMember = "CodeFamily";
    }
