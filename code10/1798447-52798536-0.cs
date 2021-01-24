    List<int> k = new List<int>();
	int f = 0;
	for(int j = SubRaces.Items.Count - 1; j >= 0; j--) {
		if(SubRaces.GetItemCheckState(j) == CheckState.Checked) {
			f = j;
     		break;
		}               
	}
	for(int i = 0; i < DNDSubRace.allSubRaces.Count; i++){
		if(DNDSubRace.allSubRaces[i].MainRace.Name == Races.SelectedItem) {
			k.Add(i);
		}
	}   
	DNDSubRace.allSubRaces [k [f]].DNDSubRaceDescription();
	SubRaceBenefits.Text = DNDSubRace.allSubRaces [k [f]].Details;
