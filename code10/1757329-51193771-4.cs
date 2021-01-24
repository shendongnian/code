    [System.Serializable]
    public class Levels{
        public LevelGrid[] levels;
        public Levels() {
        }
        public Levels(LevelGrid[] levels) {
          this.levels = levels;
        }
        public LevelGrid[] Levels{
          get { return levels; }
          set { levels= value; }
        }
        //from a jsonstring to an object
        public static Levels SaveFromString(string jsonString) {
          return JsonUtility.FromJson<Levels>(jsonString);
        }
        //object to json
        public string SaveToString() {
          return JsonUtility.ToJson(this);
        }
    }
