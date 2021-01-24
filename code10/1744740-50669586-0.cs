    void GetUserRank(string user, Action<int> rank)
    {
        Social.LoadScores("Leaderboard01", scores =>
        {
            if (scores.Length > 0)
            {
                Debug.Log("Retrieved " + scores.Length + " scores");
    
                //Filter the score with the user name
                for (int i = 0; i < scores.Length; i++)
                {
                    if (user == scores[i].userID)
                    {
                        rank(scores[i].rank);
                        break;
                    }
                }
            }
            else
                Debug.Log("Failed to retrieved score");
        });
    }
