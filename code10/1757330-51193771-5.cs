    [System.Serializable]
    public class LevelGrid{
        public string[] level1;
        public string[] level2;
        public LevelGrid() {
        }
        public LevelGrid(string[] level1, string[] level2) {
          this.level1 = level1;
          this.level2 = level2;
        }
        public string[] Level1{
          get { return level1; }
          set { level1 = value; }
        }
        public string[] Level2{
          get { return level2; }
          set { level2 = value; }
        }
        //from a jsonstring to an object
        public static LevelGrid SaveFromString(string jsonString) {
          return JsonUtility.FromJson<LevelGrid>(jsonString);
        }
        //object to json
        public string SaveToString() {
          return JsonUtility.ToJson(this);
        }
    }
