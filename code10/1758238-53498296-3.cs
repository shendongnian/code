    @page "/registration"
        @foreach (var club in ClubList())
        {
            <input type="checkbox" @onchange="eventArgs => { CheckboxClicked(club, eventArgs.Value); }" />@club<br />
        }
    @functions {
    
        public List<string> ClubMember { get; set; } = new List<string>();
        void CheckboxClicked(string clubID, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!ClubMember.Contains(clubID))
                {
                    ClubMember.Add(clubID);
                }
            }
            else
            {
                if (ClubMember.Contains(clubID))
                {
                    ClubMember.Remove(clubID);
                }
            }
        }
    
        public List<String> ClubList()
        {
            // fetch from API or...
            List<String> c = new List<String>();
            c.Add("Clube01");
            c.Add("Clube02");
            return c;
        }
    
    }
