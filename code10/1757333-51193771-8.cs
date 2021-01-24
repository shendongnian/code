    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    [System.Serializable]
    public class MyLevels{
      [SerializeField] List<LevelGrid> levels;
      public MyLevels(){}
      public MyLevels(List<LevelGrid> levels){
        this.levels = levels;
      }
      public List<LevelGrid> Levels{
        get { return levels; }
        set { levels = value; }
      }
      //from a jsonstring to an object
      public static MyLevels SaveFromString(string jsonString){
        return JsonUtility.FromJson<MyLevels>(jsonString);
      }
      //object to json
      public string SaveToString(){
        return JsonUtility.ToJson(this);
      }
    }
