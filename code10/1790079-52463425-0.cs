    public void Refresh(object sender = null, EventArgs e = null)
        {
            Leagues = new ObservableCollection<League>(_Locator.Statistix.Leagues.ToList());
            foreach(League l in Leagues)
            {
                l.Teams.RemoveAll(x => x.Year == SelectedYear);
            }
            Leagues.RemoveAll(x => x.Teams.Count == 0);
        }
