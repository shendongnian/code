    [ActiveRecord("[Big Honking Table]",
        DiscriminatorColumn = "Type",
        DiscriminatorType = "String",
        DiscriminatorValue = "Data Entry")]
    public class Data Entry : ActiveRecordBase
    {
       //Your stuff here!
    }
    
    [ActiveRecord("[Big Honking Table]",
        DiscriminatorColumn = "Type",
        DiscriminatorType = "String",
        DiscriminatorValue = "Batch Process")]
    public class Batch Process : ActiveRecordBase
    {
       //Also your stuff!
    }
