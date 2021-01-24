    CreateTable(
                "dbo.DefaultAnswers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnswerId, t.QuestionId })
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .Index(t => t.AnswerId);
