    public async Task MyMethod() {
    
        //...
    
        questionList = await _context._Question
            .Where(Question => Question.Prof_ID == id && Question.Isverified == "No")
            .ToListAsync();
        
        subjectList = await _context._Subjects.ToListAsync();
    
    }
