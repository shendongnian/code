    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication100
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Article article = doc.Descendants("Article").Select(x => new Article() { Stories = x.Elements("Story").Select(y => Story.ParseStory(y)).ToList() }).FirstOrDefault();
     
            }
     
        }
        public class InputXmlModel
        {
           public List<Article> Articles { get; set; }
        }
        public class Article
        {
            public List<Story> Stories { get; set; }
        }
        public class Story
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Lead { get; set; }
            public List<Item> Items { get; set; }
            public List<StoryPicture> Pictures { get; set; }
            enum State
            {
                DEFAULT,
                SUBTITLE,
     
            }
            public static Story ParseStory(XElement xStory)
            {
                Story story = new Story();
                State state = State.DEFAULT;
                Item newItem = null;
                StoryPicture newPicture = null;
                foreach (XElement child in xStory.Elements())
                {
                    switch(state)
                    {
                        case State.DEFAULT :
                            switch (child.Name.LocalName)
                            {
                                case "Title" :
                                    story.Title = (string)child;
                                    break;
                                case "Author":
                                    story.Author = (string)child;
                                    break;
                                case "Lead":
                                    story.Lead = (string)child;
                                    break;
                                case "Subtitle":
                                    newItem = new Item();
                                    if (story.Items == null) story.Items = new List<Item>();
                                    story.Items.Add(newItem);
                                    state = State.SUBTITLE;
                                    break;
                                case "Picture":
                                    newPicture = new StoryPicture()
                                    {
                                        ImageHref = (string)child.Element("Image").Attribute("href"),
                                        Credit = (string)child.Element("Credit"),
                                        Description = (string)child.Element("Description")
                                    };
                                    if (story.Pictures == null) story.Pictures = new List<StoryPicture>();
                                    story.Pictures.Add(newPicture);
                                    break;
                                default:
                                    Console.WriteLine("Error");
                                    Console.ReadLine();
                                    break;
                            }
                            break;
                        case State.SUBTITLE :
                            switch (child.Name.LocalName)
                            {
                                case "Body" :
                                    newItem.ItemType = "SubTitle";
                                    newItem.ItemText = (string)child;
                                    break;
                                case "Subtitle":
                                    newItem = new Item();
                                    if (story.Items == null) story.Items = new List<Item>();
                                    story.Items.Add(newItem);
                                    break;
                                default:
                                    Console.WriteLine("Error");
                                    Console.ReadLine();
                                    break;
                            }
                            break;
                    }
                }
                return story;
            }
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
