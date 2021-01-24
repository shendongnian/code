    public List<Evaluations> GetAllEvaluationsPerBook()
        {
            using (var context = new BookDbContext())
            {
                var evaluations = context.Evaluation.ToList();
                var books = context.Book.ToList();
                var users = context.User.ToList();
                               
                return evaluations;
            }
        }
