    public ILearnStrategy ResolveLearnStrategy(LearnModus learnModus, IRepository repository)
    {
        switch (learnModus)
        {
            case LearnModus.Exam:
                return new ExamLearnStrategy(repository);
            case LearnModus.Level:
                return new LevelLearnStrategy(repository);
            case LearnModus.Simple:
                return new SimpleLearnStrategy(repository);
            case LearnModus.System:
                return new SystemLearnStrategy(repository);
            default:
                return new SimpleLearnStrategy(repository);
        }
    }
