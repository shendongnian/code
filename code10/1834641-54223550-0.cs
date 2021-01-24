    [TestCase("User1@abc.com", "Pass", "Contest1 Pass")]
    [TestCase("User2@abc.com", "Fail",  "Contest1 Fail")]
    [TestCase("User3@abc.com", "Invalid",  "Contest1 Invalid")]
    [TestCase("User1@abc.com", "Pass",  "Contest2 Pass")]
    public async Task PlayContest(string email, string status,string testName)
    {
        int contestId = 1;
    
        if(testName == "Contest2 Pass")
        {
            contestId = 2;
        }
    
        //Do work here based on assigned contestId
    }
