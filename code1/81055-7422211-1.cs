    GameEntities db = new GameEntities();
    private void btnTeamFixtures_Click(object sender, RoutedEventArgs e)
        {
            txtResults.Text = null;
            
            var allTeams = db.Team.Select(t => t.TeamName);
            int numDays = allTeams.Count() - 1;
            int halfsize = allTeams.Count() / 2;
            List<string> temp = new List<string>();
            List<string> teams = new List<string>();
            teams.AddRange(allTeams);
            temp.AddRange(allTeams);
            teams.RemoveAt(0);
            int teamSize = teams.Count;
            for (int day = 0; day < numDays * 2; day++)
            {
                //Calculate1stRound(day);
                if (day % 2 == 0)
                {
                    txtResults.Text += String.Format("\n\nDay {0}\n", (day + 1));
                    int teamIdx = day % teamSize;
                    txtResults.Text += String.Format("{0} vs {1}\n", teams[teamIdx], temp[0]);
                    for (int idx = 0; idx < halfsize; idx++)
                    {
                        int firstTeam = (day + idx) % teamSize;
                        int secondTeam = ((day + teamSize) - idx) % teamSize;
                        if (firstTeam != secondTeam)
                        {
                            txtResults.Text += String.Format("{0} vs {1}\n", teams[firstTeam], teams[secondTeam]);
                        }
                    }
                }
                //Calculate2ndRound(day);
                if (day % 2 != 0)
                {
                    int teamIdx = day % teamSize;
                    txtResults.Text += String.Format("\n\nDay {0}\n", (day + 1));
                    txtResults.Text += String.Format("{0} vs {1}\n", temp[0], teams[teamIdx]);
                    for (int idx = 0; idx < halfsize; idx++)
                    {
                        int firstTeam = (day + idx) % teamSize;
                        int secondTeam = ((day + teamSize) - idx) % teamSize;
                        if (firstTeam != secondTeam)
                        {
                            txtResults.Text += String.Format("{0} vs {1}\n", teams[secondTeam], teams[firstTeam]);
                        }
                    }
                }
            }
        }
