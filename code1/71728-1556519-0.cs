     public interface IDataItem
        {
            string DisplayText { get; }
            string ActionUrl { get;  }
            bool HasChildren { get; }
            IEnumerable<IDataItem> GetChildren();
        }
    
     public void CreateTree(HtmlTextWriter writer, IEnumerable<IDataItem> collection)
        {
            writer.WriteFullBeginTag("ul");
            foreach (var data in collection)
            {
                writer.WriteFullBeginTag("li");
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href",data.ActionUrl);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(data.DisplayText);
                writer.WriteEndTag("a");
                if(data.HasChildren)
                    CreateTree(writer, data.GetChildren());
                writer.WriteEndTag("li");
            }
            writer.WriteEndTag("ul");
        }
