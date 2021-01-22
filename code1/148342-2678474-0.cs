    public interface IColumn
    {
        string Title { get; }
        string Render(MyModelObject obj);
    }
    
    public class NameColumn : IColumn
    {
        public string Title { get { return "Name"; } }
        
        public string Render(MyModelObject obj)
        {
            return obj.Name;
        }
    }
