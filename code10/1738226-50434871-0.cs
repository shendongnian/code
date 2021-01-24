    using System;
    using UnityEngine;
    
    [Serializable]
    public class PlayerStats
    {
        public int Health;
        public int Energy;
        public Vector3 Position;
    
        public static string Serialize(PlayerStats playerStats)
        {
            if (playerStats == null)
                return "";
    
            return JsonUtility.ToJson(playerStats);
        }
    
        public static PlayerStats Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
                return new PlayerStats();
    
            return JsonUtility.FromJson<PlayerStats>(json);
        }
    }
    
    public static class GameManager
    {
        public const string PLAYER_STATS_SAVE_KEY = "PLAYER_STATS";
        
        public static PlayerStats Player;
        
        public static void Save()
        {
            string json = PlayerStats.Serialize(Player);
            PlayerPrefs.SetString(PLAYER_STATS_SAVE_KEY, json);
        }
        
        public static void Load()
        {
            if (!PlayerPrefs.HasKey(PLAYER_STATS_SAVE_KEY))
            {
                Player = new PlayerStats();
            }
            else
            {
                string json = PlayerPrefs.GetString(PLAYER_STATS_SAVE_KEY);
                Player = PlayerStats.Deserialize(json);
            }
        }
    }
