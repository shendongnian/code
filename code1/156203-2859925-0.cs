    public Test()
    {
      string xml = @"<DataSet> 
                       <User> 
                         <UserName>Test</UserName> 
                           <Email>test@test.com</Email> 
                          <Details> 
                            <ID>1</ID> 
                            <Name>TestDetails</Name> 
                            <Value>1</Value> 
                          </Details> 
                          <Details> 
                            <ID>2</ID> 
                            <Name>Testing</Name> 
                            <Value>3</Value> 
                          </Details> 
                        </User> 
                      </DataSet>";
      XmlSerializer xs = new XmlSerializer(typeof(DataSet));
      DataSet ds = (DataSet)xs.Deserialize(new StringReader(xml));
    }
    [Serializable]
    public class DataSet
    {
      public User User;      
    }
    [Serializable]
    public class User
    {
      public string UserName { get; set; }
      public string Email { get; set; }
      [XmlElement]
      public Details[] Details { get; set; }
    }
    [Serializable]
    public class Details
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public string Value { get; set; }
    }
