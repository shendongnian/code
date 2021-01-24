    public class InputObject{
    	public TitlesClass titles {get;set;}
    	public SigneesClass signees {get;set;}
    }
    
    public class TitlesClass {
    	public string Title {get;set;}
    	public string SubTitle {get;set;}
    }
    
    public class SigneesClass {
    	public string SigneeTitle0 {get;set;}
    	public string SigneeTitle1 {get;set;}
    	public string SigneeTitle2 {get;set;}
    }
    public void ReadFormDataFile(string fileLocation)
    {
        string tmp = File.ReadAllText(fileLocation);
        InputObject parsedObject = JsonConvert.DeserializeObject<InputObject>(tmp);
    }
