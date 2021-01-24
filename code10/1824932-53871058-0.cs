    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication93
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                Context dbContext = new Context();
                var results = (from n in dbContext.news 
                               join c in dbContext.category.OrderBy(x => x.Date) on n.Id equals c.Id 
                               select new { news = n, category = c})
                               .Select((x,i) => new { Date = x.news.Date, CategoryTitle = x.category.Title, Title = x.news.Title, Description = x.news.Description, Image = x.news.Image, RankNo = i})
                               .ToList();
     
            }
        }
        public class Context
        {
            public List<News> news { get; set; }
            public List<Category> category { get; set; }
        }
        public class News
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Title { get;set;}
            public string Description { get;set;}
            public byte[] Image { get;set;}
        }
        public class Category
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
        }
     
    }
