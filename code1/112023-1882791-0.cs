    class FootballTeam
    {
        public event EventHandler ManagerChanged;
        
        protected virtual void OnManagerChanged(EventArgs e)
        {
            EventHandler handler = ManagerChanged;
            if (handler != null)
                handler(this, e);
        }
        public void OnOtherManagerChanged(object sender, EventArgs e)
        {
            FootballTeam otherTeam = (FootballTeam) sender;
            // A manager changed on a different FootballTeam instance
            //  ...do something here
        }
    }
