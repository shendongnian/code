    List<int> k = DNDSubRace.allSubRaces.Where(r=>r.MainRace.Name == Races.SelectedItem).ToList();
    int f = 0;
    for(int j = SubRaces.Items.Count - 1; j >= 0; j--) {
        if(SubRaces.GetItemCheckState(j) == CheckState.Checked) {
            f = j;
            break;
        }               
    }
    DNDSubRace.allSubRaces [k [f]].DNDSubRaceDescription();
    SubRaceBenefits.Text = DNDSubRace.allSubRaces [k [f]].Details;
