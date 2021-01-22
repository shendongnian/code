    using (var database = new Database()) try
    {
        var poll = // Some database query code.
    
        foreach (Question question in poll.Questions) {
            foreach (Answer answer in question.Answers) {
                database.Remove(answer);
            }
    
            // This is a sample line  that simulate an error.
            throw new Exception("deu pau"); 
    
            database.Remove(question);
        }
    
        database.Remove(poll);
    }
    catch( /*...Expected exception type here */ )
    {
        database.Rollback();
    }
