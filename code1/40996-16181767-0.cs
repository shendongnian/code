        public string LoadRandomNews(int maxNews)
        {
            string temp = "";
            using (var db = new DataClassesDataContext())
            {
                var newsCount = (from p in db.Tbl_DynamicContents
                                 where p.TimeFoPublish.Value.Date <= DateTime.Now
                                 select p).Count();
                int i;
                if (newsCount < maxNews)
                    i = newsCount;
                else i = maxNews;
                var r = new Random();
                var lastNumber = new List<int>();
                for (; i > 0; i--)
                {
                    int currentNumber = r.Next(0, newsCount);
                    if (!lastNumber.Contains(currentNumber))
                    { lastNumber.Add(currentNumber); }
                    else
                    {
                        while (true)
                        {
                            currentNumber = r.Next(0, newsCount);
                            if (!lastNumber.Contains(currentNumber))
                            {
                                lastNumber.Add(currentNumber);
                                break;
                            }
                        }
                    }
                    if (currentNumber == newsCount)
                        currentNumber--;
                    var news = (from p in db.Tbl_DynamicContents
                                orderby p.ID descending
                                where p.TimeFoPublish.Value.Date <= DateTime.Now
                                select p).Skip(currentNumber).Take(1).Single();
                    temp +=
                        string.Format("<div class=\"divRandomNews\"><img src=\"files/1364193007_news.png\" class=\"randomNewsImg\" />" +
                                      "<a class=\"randomNews\" href=\"News.aspx?id={0}\" target=\"_blank\">{1}</a></div>",
                                      news.ID, news.Title);
                }
            }
            return temp;
        }
    
