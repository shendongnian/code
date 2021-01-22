    [XmlRoot("Results")]
    public class Results
    {
      List<Result> results = new List<Result>();
    
      [XmlElement("Result")]
      List<Result> Results {get{return results;}}
    }
    
    public class Result
    {
      List<Operation> operations = new List<Operation>();
      int WorkorderId {get; set;}
      .... other fields
      string Note{get;set;}
      List<Operation> Operations {get{return operations;}}
    }
    
    public class Operation
    {
      List<string> parsedInformation = new List<string>();
      int OperationId {get;set;}
      ....
      [XmlArray("ParsedInformation")]
      [XmlArrayItem("Info")]
      List<string> ParsedInformation{get{return parsedInformation;}}
    }
