    public sealed partial class MainPage : Page
    {
        // The variable to hold the input
        Windows.Storage.Streams.InMemoryRandomAccessStream stream = 
        new Windows.Storage.Streams.InMemoryRandomAccessStream(); 
 
        public void storeInput()
        {
            RichEditBox.Document.SaveToStream
            (Windows.UI.Text.TextGetOptions.FormatRtf, stream);
        }
    }
