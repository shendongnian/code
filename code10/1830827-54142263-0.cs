    [System.Serializable]
    [XmlRoot("GameData")]
    public class GameData
    {
        [XmlArray("Challenges")]
        [XmlArrayItem("ChallengeStatus)]
        public List<ChallengeStatus> Challenges;
        
        //...
    }
