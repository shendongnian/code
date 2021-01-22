    // You can think of a role a person would do for a manual process as a class
    // in a program.
    public class ScoreKeeper
    {
        // Our high score list (stack of cards) is empty to begin with.  Unlike
        // arrays, lists allow us insert items rather than placing them in 
        // numbered slots.
        private List<int> _scores = new List<int>();
        
        // This is the method for when someone asks us to record a score.  The
        // "score" parameter is the new score which you can think of as being 
        // written on a card.
        public void RecordScore(int score)
        {
            // Go through each of the existing scores.  "i" is the index in the
            // list.
            for (int i = 0; i < _scores.Count; i++)
            {
                // See if the new score is less than the score at index #i
                if (_scores[i] < score)
                {
                    // It is lower than this new score.  Insert the new score
                    // above that score.
                    _scores.Insert(i, score);
                    
                    // We're done.  Stop looping and exit RecordScore.
                    return;
                }
            }
            
            // If we get here, we found no scores lower than this new one.  Add 
            // this score to the bottom of the stack.
            _scores.Add(score);
        }
        
        // This is the method for when someone asks us for the top 10 scores.
        // Notice that we return an array of integers, which will represent 
        // our piece of paper we hand back to the one requesting the scores.
        public int[] GetTop10Scores()
        {
            // We start with a blank piece of paper.
            int[] result = new int[10];
            
            // Go through the scores.  The first 10 are the top 10 because
            // RecordScore puts them in order.  We also need to make sure
            // we don't try to get more scores than we've recorded.
            for (int i = 0; i < 10 && i < _scores.Count; i++)
            {
                // Write down the score on the paper
                result[i] = _scores[i];
            }
            
            // Send back the list of scores to the requester
            return result;
        }
    }
