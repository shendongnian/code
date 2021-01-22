    void LoadToDictionary(Dictionary<string, string> dict, string filePath)
    { ... code here ... }
    //to have a LoadToDictionary method which accepts Dictionary<int, int>
    void LoadToDictionary(Dictionary<int, int> dict, string filePath)
    
    //To change the processing logic, you either need a new method name, 
    // or to override the original in an inheriting class
    void AlternateLoadToDictionary(Dictionary<string, string> dict, string filePath)
    override void LoadToDictionary(Dictionary<string, string> dict, string filePath)
