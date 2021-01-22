    [Guid("77699130-7D58-4d29-BE18-385871B000D1")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IExample
    {
    	[DispId(1)]
    	string GetText();
    	
    	[DispId(2)]
        void SetText(string text);
    }
    
    [Guid("F91E5EE1-D220-43b5-90D1-A48E81C478B7")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class Example : IExample
    {
    	private string m_text = "default text";
    
    	[ComVisible(true)]
        public string GetText()
        {
          return m_text;
        }
    
    	[ComVisible(true)]
        public void SetText(string text)
        {
          m_text = text;
        }
    }
