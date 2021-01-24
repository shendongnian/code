    [Serializable]
    public class TestData {
       public string Whatever;
    }
    IDataObject dataObject = new DataObject();
    dataObject.SetData( "System.String", "Test" );
    dataObject.SetData( "Text", "Test" );
    dataObject.SetData( "UnicodeText", "Test" );
    dataObject.SetData( "OEMText", "Test" );
    dataObject.SetData( "TestData", new TestData() { Whatever = "NONONONONO", } );
    Clipboard.SetDataObject( dataObject );
