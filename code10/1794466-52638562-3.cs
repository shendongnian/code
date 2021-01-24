    public class MyCustomControl
    {
        public override string ToString()
        {
            return Render();
        }
        public string Render()
        {
            TagBuilder mainContainer = new TagBuilder("div");
            mainContainer.Attributes.Add(new KeyValuePair<string, string>("data-id","123") );
            // Generate child elements and append to mainContainer...
            using (StringWriter writer = new StringWriter())
            {
                mainContainer.WriteTo(writer, HtmlEncoder.Default);
                var result=writer.ToString();
                return result;
            }
        }
    
