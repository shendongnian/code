    using System;
    using System.Collections.Generic;
    using System.Linq;
    using JetBrains.Annotations;
    using UnityEngine;
    
    public class NewBehaviourScript : MonoBehaviour
    {
        private void Start()
        {
            var scores = new List<Score>
            {
                new Score("Bart", 100),
                new Score("Maggie", 75),
                new Score("Lisa", 50),
                new Score("Marge", 25),
                new Score("Homer", 0)
            };
    
            var table = new ScoreTable(scores);
    
            // save to JSON
            var json = JsonUtility.ToJson(table, true);
    
            // load from JSON
            var fromJson = JsonUtility.FromJson<ScoreTable>(json);
    
            // print the top 3 players
    
            var take = fromJson.Scores.OrderByDescending(s => s.Points).Take(3);
    
            foreach (var score in take)
                Debug.Log($"{score.Name}: {score.Points}");
        }
    }
    
    [Serializable]
    public class ScoreTable
    {
        public List<Score> Scores = new List<Score>();
    
        public ScoreTable()
        {
            // for serializer
        }
    
        public ScoreTable([NotNull] List<Score> scores)
        {
            if (scores == null)
                throw new ArgumentNullException(nameof(scores));
    
            Scores = scores;
        }
    }
    
    [Serializable]
    public class Score
    {
        public string Name;
        public int Points;
    
        public Score()
        {
            // for serializer
        }
    
        public Score(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }
