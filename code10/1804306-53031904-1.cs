    [Test]
    public void ShouldSortOnMultipleQuestionsWithOneChosenAnswerPerQuestion()
    {
        // Assemble
        var services = SortContext.GivenServices();
        var sortProvider = services.WhenCreateSortProvider();
        var answers = new List<AnswerRequestModel>
        {
            new AnswerRequestModel
            {
                Id = 1,
                Priority = 0,
                Question = new QuestionRequestModel { Type = QuestionType.Two },
                Text = "Very high",
                Formulas = new List<AnswerFormula> { new AnswerFormula { Expression = "Very high", Operator = "=", Field = "quality"} }
            },
            new AnswerRequestModel
            {
                Id = 2,
                Priority = 1,
                Question = new QuestionRequestModel { Type = QuestionType.Two },
                Text = "High",
                Formulas = new List<AnswerFormula> { new AnswerFormula { Expression = "High", Operator = "=", Field = "quality"} }
            },
            new AnswerRequestModel
            {
                Id = 3,
                Priority = 2,
                Question = new QuestionRequestModel { Type = QuestionType.Two },
                Text = "Medium",
                Formulas = new List<AnswerFormula> { new AnswerFormula { Expression = "Medium", Operator = "=", Field = "quality"} }
            },
            new AnswerRequestModel
            {
                Id = 4,
                Priority = 3,
                Question = new QuestionRequestModel { Type = QuestionType.Two },
                Text = "Low",
                Formulas = new List<AnswerFormula> { new AnswerFormula { Expression = "Low", Operator = "=", Field = "quality"} }
            },
            new AnswerRequestModel
            {
                Id = 5,
                Priority = 0,
                Question = new QuestionRequestModel { Type = QuestionType.Two, Priority = 1},
                Text = "Blacks",
                Formulas = new List<AnswerFormula> { new AnswerFormula { Expression = "Blacks", Operator = "=", Field = "colour"} }
            },
            new AnswerRequestModel
            {
                Id = 6,
                Priority = 1,
                Question = new QuestionRequestModel { Type = QuestionType.Two, Priority = 1 },
                Text = "Silvers",
                Formulas = new List<AnswerFormula> { new AnswerFormula { Expression = "Silvers", Operator = "=", Field = "colour" } }
            },
            new AnswerRequestModel
            {
                Id = 7,
                Priority = 2,
                Question = new QuestionRequestModel { Type = QuestionType.Two, Priority = 1 },
                Text = "Reds",
                Formulas = new List<AnswerFormula> { new AnswerFormula { Expression = "Blues", Operator = "=", Field = "colour" } }
            },
            new AnswerRequestModel
            {
                Id = 8,
                Priority = 3,
                Question = new QuestionRequestModel { Type = QuestionType.Two, Priority = 1 },
                Text = "Yellows",
                Formulas = new List<AnswerFormula> { new AnswerFormula { Expression = "Yellows", Operator = "=", Field = "colour" } }
            }
        };
        answers[1].Active = true;
        answers[6].Active = true;
        // Act
        var sortedAnswers = sortProvider.SortAnswersByPriority(answers);
        var firstAnswer = sortedAnswers[0];
        var secondAnswer = sortedAnswers[1];
        var thirdAnswer = sortedAnswers[2];
        var forthAnswer = sortedAnswers[3];
        var fifthAnswer = sortedAnswers[4];
        var sixthAnswer = sortedAnswers[5];
        var seventhAnswer = sortedAnswers[6];
        var eigthAnswer = sortedAnswers[7];
        // Assert
        firstAnswer.Text.Should().Be("High");
        secondAnswer.Text.Should().Be("Very high");
        thirdAnswer.Text.Should().Be("Medium");
        forthAnswer.Text.Should().Be("Low");
        fifthAnswer.Text.Should().Be("Reds");
        sixthAnswer.Text.Should().Be("Blacks");
        seventhAnswer.Text.Should().Be("Silvers");
        eigthAnswer.Text.Should().Be("Yellows");
    }
