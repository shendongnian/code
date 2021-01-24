    public async Task<IEnumerable<T>> GetQuestionsForUser<T>(int userId)
    {
        IEnumerable<Answer> foundAnswers = await this.repository.getAnswersByUser(userId);
    
        return Mapper.Map<IEnumerable<T>>(foundAnswers);
    }
    
    IEnumerable<AnswerMinimalDto> a = await GetQuestionsForUser<AnswerMinimalDto>(foundAnswers);
    IEnumerable<AnswerFullDto> b = await GetQuestionsForUser<AnswerFullDto>(foundAnswers);
