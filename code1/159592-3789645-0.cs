            Product product = new Product();
            List<CoverageCondition> covCondList = null;
            CoverageCondition covCond = null;
            Question question = null;
            List<Question> questList = null;
            var prod = db.PRODUCTs.Include("COVERAGE_CONDITION").Include("QUESTION").Where(p => p.PRODUCT_CODE == productCode).FirstOrDefault();
            product.ProductId = prod.PRODUCT_ID;
            product.ProductCode = prod.PRODUCT_CODE;
            product.ProductName = prod.PRODUCT_NAME;
            // go through coverage conditions
            covCondList = new List<CoverageCondition>();
            product.CoverageConditions = covCondList;
            foreach (COVERAGE_CONDITION cc in prod.COVERAGE_CONDITION)
            {
                covCond = new CoverageCondition();
                covCond.ConditionId = cc.COV_CONDITION_ID;
                covCond.ConditionCode = cc.COV_CONDITION_CODE;
                covCond.ConditionName = cc.COV_CONDITION_NAME;
                covCondList.Add(covCond);
                // go through questions for each coverage condtion, if any
                questList = new List<Question>();
                covCond.Questions = questList;
                foreach (QUESTION q in cc.QUESTIONs)
                {
                    question = new Question();
                    question.QuestionId = q.QUESTION_ID;
                    question.QuestionCode = q.QUESTION_CODE;
                    question.QuestionText = q.QUESTION_TEXT;
                    questList.Add(question);
                }
            }
