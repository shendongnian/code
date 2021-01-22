      public List<Model.Question> GetSurveyQuestions(string type, int typeID)
        {
            using (eMTADataContext db = DataContextFactory.CreateContext())
            {
                return db.Survey_Questions
                         .Where(s => s.Survey.Type.Equals(type) && s.Survey.Type_ID.Equals(typeID))
                         .Join(db.Questions,
                                  sq => sq.Question_ID,
                                  q => q.ID,
                                  (sq, q) => Mapper.ToBusinessObject(q, sq.Status)).ToList();
            }
        }
