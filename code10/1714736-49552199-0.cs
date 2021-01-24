    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    
    
    
    namespace ScoreBoard
    {
        [Serializable]
        public class PlayerScore
    
        {
            public string Name;
            public int Score;
    
            public PlayerScore(string name, int score)
            {
                Name = name;
                Score = score;
            }
        }
    
        [Serializable]
        // we need to store list of scores in a container class so we can change it to json 
        public  class PlayerScoresRankedListContainer
        {
            public  List<PlayerScore> PlayerScoresRanked = new List<PlayerScore>();
        }
    
    
        [Serializable]
        public class ScoresRanked  : MonoBehaviour
        {
            public static PlayerScoresRankedListContainer PlayerScoresListContainer =new PlayerScoresRankedListContainer();
    
            public void Awake()
            {
                //example of usage 
          
                //get saved items
                if (PlayerPrefs.GetString("PlayerScoresRanked").Length > 0)
                {
                    PlayerScoresListContainer.PlayerScoresRanked = GetSortedListFromPlayerPrefs();
                    DebugShowScores();
                }
                else
                {
                    //test the class asving items 
    
                    AddScoreToRankedList("player1", 1000);
                    AddScoreToRankedList("player2", 20);
                    AddScoreToRankedList("player3", 100);
                    SaveListAsJSONInPlayerPrefs();
                }
    
            }
      
            private void AddScoreToRankedList(string player, int currentScore)
            {
    
                var score = new PlayerScore(player, currentScore);
    
                if (DoesScoreAlreadyExist(score))
                {
                    //we remove a score if it already exists so we can updated it 
                    //you might not need this maybe you just want to keep adding scores
                    PlayerScoresListContainer.PlayerScoresRanked.RemoveAll(x => x.Name == score.Name);
                    PlayerScoresListContainer.PlayerScoresRanked.Add(score);
    
                }
                else
                {
                    PlayerScoresListContainer.PlayerScoresRanked.Add(score);
                }
    
    
            }
    
            public void SaveListAsJSONInPlayerPrefs()
            {
                
    
               var jsonlist = JsonUtility.ToJson(PlayerScoresListContainer);
    
                Debug.Log("LOG ITEMS BEING SAVED: "+jsonlist);
    
                PlayerPrefs.SetString("PlayerScoresRanked", jsonlist);
            }
    
            public List<PlayerScore> GetSortedListFromPlayerPrefs()
            {
                var jsonlist = PlayerPrefs.GetString("PlayerScoresRanked");
    
                var ListContainer = JsonUtility.FromJson<PlayerScoresRankedListContainer>(jsonlist);
    
                var listsorted = ListContainer.PlayerScoresRanked.OrderByDescending(x => x.Score).ToList();
    
                return listsorted;
            }
    
            public bool DoesScoreAlreadyExist(PlayerScore scoreToChcek)
            {
                if (PlayerScoresListContainer.PlayerScoresRanked.Exists(x => x.Name == scoreToChcek.Name))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            public void DebugShowScores()
            {
                foreach (var playerScore in PlayerScoresListContainer.PlayerScoresRanked)
                {
                    Debug.Log(playerScore.Name + " " + playerScore.Score);
                }
            }
    
        }
    
    }
