        public class Comment
        {
            public int Id { get; set; }
            public int ParentId { get; set; }
            public string Text { get; set; }
            public List<Comment> Children { get; set; }
        }
        public JsonResult Test()
        {
            List<Comment> categories = new List<Comment>()
            {
                new Comment () { Id = 1, Text = "Yabancı Dil", ParentId = 0},
                new Comment() { Id = 2, Text = "İngilizce", ParentId = 1 },
                new Comment() { Id = 3, Text = "YDS", ParentId = 2 },
                new Comment() { Id = 4, Text = "TOEFL", ParentId = 2 },
                new Comment() { Id = 5, Text = "YDS Seviye1", ParentId = 3 },
                new Comment() { Id = 6, Text = "TOEFL Seviye1", ParentId = 4 }
            };
            
            List<Comment> hierarchy = new List<Comment>();
            hierarchy = categories
                            .Where(c => c.Id == 2)
                            .Select(c => new Comment()
                            {
                                Id = c.Id,
                                Text = c.Text,
                                ParentId = c.ParentId,
                                Children = GetChildren(categories, c.Id)
                            })
                            .ToList();
            
            List<Comment> list = new List<Comment>();
            List<string> list2 = new List<string>();
            if (hierarchy != null)
            {
                liste.AddRange(hierarchy);
                
            }
            
            return Json(liste, JsonRequestBehavior.AllowGet);
        }
        public static List<Comment> GetChildren(List<Comment> comments, int parentId)
        {
            hAbDbContext db = new hAbDbContext();
            return comments
                    .Where(c => c.ParentId == parentId)
                    .Select(c => new Comment()
                    {
                        Id = c.Id,
                        Text = c.Text,
                        ParentId = c.ParentId,
                        Children = GetChildren(comments, c.Id)
                    })
                    .ToList();
        }
