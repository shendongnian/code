    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace  temp
    {
    
        public class GameLoop
        {
            private SaveGameManager sgManager;
            private GameData data;
            private bool isPlaying;
    
            public GameLoop()
            {
                sgManager = new SaveGameManager("MYSAVELOCATION");
                data = sgManager.LoadGame();
                isPlaying = true;
            }
    
            private void PlayGame()
            {
                while (isPlaying)
                {
                    //All of your game code
                }
            }
    
    
    
        }
    
        public class SaveGameManager
        {
            private string saveFile;
            private BinaryFormatter formatter;
    
            public SaveGameManager(string file)
            {
                saveFile = file;
                formatter = new BinaryFormatter();
            }
    
            public GameData LoadGame()
            {
                using (StreamReader reader = new StreamReader(saveFile))
                {
                    return (GameData)formatter.Deserialize(reader.BaseStream);
                }
            }
    
            public void SaveGame(GameData data)
            {
                using (StreamWriter writer = new StreamWriter(saveFile))
                {
                    formatter.Serialize(writer.BaseStream, data);
                }
            }
        }
    
        [Serializable]
        public struct GameData
        {
            public int units;
            public int scanRange;
            public int gains;
            public int reputation;
            public int clicks;
            public Dictionary<string, bool> upgradesPurchased;
            public Dictionary<string, bool> upgradesOwned;
            public Dictionary<string, bool> achievementsEarned;
        }
    
    
    
    }
