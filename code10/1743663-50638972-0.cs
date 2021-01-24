    [System.Serializable]
    public class Question {
        public string studentPin;
    }
    [System.Serializable]
    public class ServerRequest {
        public string operation;
        public Question question;
    }
    //Do your instantiation, setups, etc as above.
    string json = JsonUtility.ToJson(request);
