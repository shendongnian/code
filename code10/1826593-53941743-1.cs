        var fakeLessonList = new List<Lesson>
        {
            new Lesson() { LessonId = 1, LessonTypeId = 1,LanguageId = 1, TeacherId = 1, LessonName = "Professional Lesson"},
            new Lesson() { LessonId = 2,LessonTypeId = 2, LanguageId = 2, TeacherId = 2, LessonName = "Professional Lesson"}
        }.AsQueryable(); // .BuildMock(); - no mock, just a real list
        _mockUnitOfWork.Setup(uow => uow.Repository<Lesson>().GetEntities(It.IsAny<Expression<Func<Lesson, bool>>>(),
            It.IsAny<Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>>()))
                .Returns(
                    (Expression<Func<Lesson, bool>> condition,
                     Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> include) =>
                    // Run the queries against the list
                    // Need to add some checks in case any of those are null
                    fakeLessonList.Where(condition)
                );
