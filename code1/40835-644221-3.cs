    [Serializable]
    public class User
    {
       private string _userID;
    
       [XmlElement()]
       public string UserID
       {
          get { return _userID; }
          set { _userID = value; }
       }
    }
