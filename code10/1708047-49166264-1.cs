    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var ele = new Election();
    		var ui = new ElectionUI(ele);
    		ui.candidateInfo();
    		ele.findWinner();
    		
    	}
    }
    
    class ElectionUI 
    {
    	Election theElection;
    	public ElectionUI(Election obj)
    	{
    		theElection = obj;
    	}
    	
        public void candidateInfo() 
        {
             do
             {
                 for (int i = 0; i < theElection.CandidateNames.Length; i++)
                 {
                    Console.Write("Please enter the name for Candidate #" + (i + 
                    1) + ": ");
                    theElection.CandidateNames[i] = Console.ReadLine();
                    Console.Write("Please enter the number of votes for: {0}: ", 
                    theElection.CandidateNames[i]);
                    theElection.NumVotes[i] = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                 }
             } while (theElection.NumVotes.Length < 5);
        }
    }
    
    class Election 
    {
        private string[] candidateNames = new string[5];
        private int[] numVotes = new int[5];        
            //get/set Candidate Names
            public string[] CandidateNames 
            {
                get { return candidateNames; }
                set { candidateNames = value; }
            }
    
            //Get/Set Candidate votes
            public int[] NumVotes 
            {
                get { return numVotes; }
                set { numVotes = value; }
            }
    
        public void findWinner()
        {
            int max = NumVotes.Max();
                for (var i = 0; i < numVotes.Length; i++)
                {
                    if (NumVotes[i] > max) 
                    {
                        max = NumVotes[i];
                    }
                }
            Console.WriteLine(max);
        }
    }
