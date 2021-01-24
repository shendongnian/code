    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{		
    		// create Questions
    		
    		var questionOne = new Question(){QuestionId = 1, ActualQuestion = "Who"};
    		var questionTwo = new Question(){QuestionId = 2, ActualQuestion = "What"};
    		var questionThree = new Question(){QuestionId = 3, ActualQuestion = "Where"};
    		
    		// Assign questions to the specified list of questions
    		
    		var applicationOneQuestions = new List<Question>(){questionOne, questionTwo, questionThree};
    		var applicationTwoQuestions = new List<Question>() {questionOne, questionTwo};
    		var applicationThreeQuestions = new List<Question>() {questionOne, questionThree};
    		var applicationFourQuestions = new List<Question>() {questionOne};
    		
    		// Create Applications
    		
    		var applicationOne = new Application(){AppId = 1, Questions = applicationOneQuestions};
    		var applicationTwo = new Application(){AppId = 2, Questions = applicationTwoQuestions};
    		var applicationThree = new Application() {AppId = 3, Questions = applicationThreeQuestions};
    		var applicationFour = new Application() {AppId = 4, Questions = applicationFourQuestions};
    		
    		// Create List of Applications
    		
    		var lstApplications = new List<Application>(){applicationOne, applicationTwo, applicationThree, applicationFour};
    		
    		// Group Applications based on Questions and cast to Section Object
    		
    		var groupApplications = lstApplications.GroupBy(x => x.Questions).Select(t => new Section { AppIds = t.Select(z => z.AppId).ToList() , Questions = t.Key}).ToList();
    		
    		foreach(var item in groupApplications)
    		{
    			foreach(var appId in item.AppIds)
    			{
    				Console.WriteLine(appId);
    				
    			}
    			
    			foreach(var question in item.Questions)
    			{
    				Console.WriteLine(question.ActualQuestion);
    			}
			    Console.WriteLine("\n");
    		}
    	}
    }
    
    public class Application
        {
            public int AppId { get; set; }
            public List<Question> Questions { get; set; }
        }
    
    public class Section
           {
                public List<int> AppIds { get; set; }
                public List<Question> Questions { get; set; }
            }
    
    public class Question
    {
    	public int QuestionId {get;set;}
    	public string ActualQuestion {get;set;}	
    }
