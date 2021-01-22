    public class PostAPI
    {
        [Path("/widgets")]
        public Widget[] GetWidgets()
        {
            return Widget.GetAll();
        }
        [Verb("POST")]
        [Path("/widgets")]
        public void CreateWidget([RequestBody] Widget w)
        {
            w.Created = DateTime.UtcNow;
            w.Create();
        }
    }
    public class Widget
    {
        public string Author;
        public string Text;
        public string Created;
        // (Methods would be here...)
    }
