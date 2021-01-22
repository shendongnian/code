        public static object GetMostDiscussedQuestions()
        {
            using (AbToBolDataClassesDataContext db = new AbToBolDataClassesDataContext())
            {
                List<vw_QuestionMaster> query = db.sp_GetQuestions(1, null, null, 1, 5).ToList();
                return query;
            }
        }
