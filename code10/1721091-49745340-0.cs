    dbContext.TestSubjects.Add(model.TestSubject);
        dbContext.SaveChanges();
        Test test = new Test
        {
            // set your foreign key values
            LanguageId = 1,
            FacilityId = 12,
            TestSubjectId = 22,
            EvaluationState = "Not Started"
        };
        dbContext.Tests.Add(test);
        dbContext.SaveChanges();
