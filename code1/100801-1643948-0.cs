    class Program
    {
        static void Main(string[] args)
        {
            var array = new string[] { "video", "photo", "hurf", "photo" };
            var ml = new MediaList(array);
            foreach(var element in ml)
                Console.WriteLine(element.GetType().Name);
            Console.Read();
        }
    }
    public class Media { }
    public class Video : Media { }
    public class Photo : Media { }
    public class MediaList
    {
        private string[] elements;
        public MediaList(string[] elements) { this.elements = elements; }
        public IEnumerator<Media> GetEnumerator()
        {
            foreach (string s in elements)
                switch (s)
                {
                    case "video":
                        yield return new Video();
                        break;
                    case "photo":
                        yield return new Photo();
                        break;
                }
        }
    }
