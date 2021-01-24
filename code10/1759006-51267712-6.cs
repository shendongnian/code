    private void ShowSelectedTeam(Object sender, RoutedEventArgs args)
    {
        GetDivisionNames();
        dgTeams.SelectionUnit = DataGridSelectionUnit.FullRow;
        dynamic selectedTeam = dgTeams.SelectedItem;
        if (selectedTeam == null) return;
        tbxTeam.Text = selectedTeam.name.ToString();
        tbxBeliggenhet.Text = selectedTeam.beliggenhet.ToString();
        tbxArena.Text = selectedTeam.arena.ToString();
        cbxDivisions.Text = selectedTeam.division.ToString();
    }
