       using System.Collections.Generic;
      [System.SerializableAttribute()]
     [System.ComponentModel.DesignerCategoryAttribute("code")]
     [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
     [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = 
     false)]
     public partial class LeaderboardModel
     {
    private List<LeaderboardModelScoreModels> scoreModelsField;
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ScoreModels")]
    public List<LeaderboardModelScoreModels> ScoreModels
    {
        get
        {
            return this.scoreModelsField;
        }
        set
        {
            this.scoreModelsField = value;
        }
    }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
     public partial class LeaderboardModelScoreModels
    {
    private LeaderboardModelScoreModelsScoreModel scoreModelField;
    /// <remarks/>
    public LeaderboardModelScoreModelsScoreModel ScoreModel
    {
        get
        {
            return this.scoreModelField;
        }
        set
        {
            this.scoreModelField = value;
        }
    }
    }
     [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class LeaderboardModelScoreModelsScoreModel
    {
    private string nameField;
    private string gameSpeedField;
    private byte scoreField;
    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
    /// <remarks/>
    public string GameSpeed
    {
        get
        {
            return this.gameSpeedField;
        }
        set
        {
            this.gameSpeedField = value;
        }
    }
    /// <remarks/>
    public byte Score
    {
        get
        {
            return this.scoreField;
        }
        set
        {
            this.scoreField = value;
        }
      }
    }
