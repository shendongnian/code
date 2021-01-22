    [Serializable]
    public class MyClassThatKeepTheData
    {
    	public int EnaTest;
    }
    
    MyClassThatKeepTheData cTheObject = new MyClassThatKeepTheData();
    
    ObjectToXML(typeof(MyClassThatKeepTheData), cTheObject)
