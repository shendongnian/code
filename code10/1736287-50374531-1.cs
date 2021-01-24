    public class CustomXmlTextWriter : XmlTextWriter
    {
    
        //... constructor if you need it
        public override void WriteString(string text)
        {
            if (text.StartsWith("<![CDATA[") && text.EndsWith("]]>"))
            {
                base.WriteRaw(text);
                return;
            }
            base.WriteString(text);
        }
    }
