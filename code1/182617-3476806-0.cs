        private void QueryMyData()
        {
            MyDbmlFileNameDataContext context = new MyDbmlFileNameDataContext("Server=XXXX\\SQLEXPRESS;Database=WebExcerciseDB;" + "Integrated Security=True");
            var query = from c in context.CommentsTable
                        where c.PersonName == "John Doe"        // This is optional if you want to sub-select.
                        select c;
            foreach (var comment in query)
            {
                Console.WriteLine(comment.PersonName + " " + comment.PersonMail + " " comment.Comment);
            }
        }
