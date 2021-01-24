    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    namespace QgeImagingXmlConnector.Domain
    {
        [XmlRoot(ElementName = "Root")]
        public class InputXmlModel
        {
            [XmlElement("Article")]
            public List<Article> Articles { get; set; }
        }
    
    
        public class Article
        {
            [XmlElement("Story")]
            public List<Story> Stories { get; set; }
        }
    
        public class Story
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Lead { get; set; }
            [XmlElement("Item")]
            public List<Item> Items { get; set; }
            [XmlElement("Picture")]
            public List<StoryPicture> Pictures { get; set; }
        }
    
        public class StoryPicture
        {
            public string ImageHref { get; set; }
            public string Credit { get; set; }
            public string Description { get; set; }
        }
    
    
        public class Item
        {
            public string ItemType { get; set; } //   Possible: Body or Subtitle
            public string ItemText { get; set; }
        }
    }
