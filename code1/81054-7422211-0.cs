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
                    txtResults.Text += "\n\n" + String.Format("Day {0}", (day + 1) + "\n");
                    int teamIdx = day % teamSize;
                    txtResults.Text += String.Format("{0} vs {1}", teams[teamIdx], temp[0] + "\n");
                    for (int idx = 0; idx < halfsize; idx++)
                    {
                        int firstTeam = (day + idx) % teamSize;
                        int secondTeam = ((day + teamSize) - idx) % teamSize;
                        if (firstTeam != secondTeam)
                        {
                            txtResults.Text += String.Format("{0} vs {1}", teams[firstTeam], teams[secondTeam] + "\n");
                        }
                    }
                }
                //Calculate2ndRound(day);
                if (day % 2 != 0)
                {
                    int teamIdx = day % teamSize;
                    txtResults.Text += "\n\n" + String.Format("Day {0}", (day + 1) + "\n");
                    txtResults.Text += String.Format("{0} vs {1}", temp[0], teams[teamIdx] + "\n");
                    for (int idx = 0; idx < halfsize; idx++)
                    {
                        int firstTeam = (day + idx) % teamSize;
                        int secondTeam = ((day + teamSize) - idx) % teamSize;
                        if (firstTeam != secondTeam)
                        {
                            txtResults.Text += String.Format("{0} vs {1}", teams[secondTeam], teams[firstTeam] + "\n");
                        }
                    }
                }
            }
        }
