    public class stories
    {
        [XmlElement("story")]
        public story[] storyarray { get; set; }
    }
...
            var byteArray = Encoding.ASCII.GetBytes(value);
            XmlSerializer serializer = new XmlSerializer(typeof(stories));
            var stream = new MemoryStream(byteArray);
            stories myStories = (stories)serializer.Deserialize(stream);
            foreach (story stor in myStories.storyarray)
                Console.WriteLine(stor.story_type);
