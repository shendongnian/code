    public static Interval[] GetRandomIntervals( DateTime start, DateTime end,
        StateSummary[] states, int totalIntervals )
    {
        Random r = new Random();
        // stores the number of intervals to generate for each state
        int[] intervalCounts = new int[states.Length];
        int intervalsTemp = totalIntervals;
        // assign at least one interval for each of the states
        for( int i = 0; i < states.Length; i++ )
            intervalCounts[i] = 1;
        intervalsTemp -= states.Length;
        // assign remaining intervals randomly to the various states
        while( intervalsTemp > 0 )
        {
            int iState = r.Next( states.Length );
            intervalCounts[iState] += 1;
            intervalsTemp -= 1;
        }
        // make a scratch copy of the state array
        StateSummary[] statesTemp = (StateSummary[])states.Clone();
        List<Interval> result = new List<Interval>();
        DateTime next = start;
        while( result.Count < totalIntervals )
        {
            // figure out which state this interval will go in (this could
            // be made more efficient, but it works just fine)
            int iState = r.Next( states.Length );
            if( intervalCounts[iState] < 1 )
                continue;
            intervalCounts[iState] -= 1;
            // determine how long the interval should be
            int length;
            if( intervalCounts[iState] == 0 )
            {
                // last one for this state, use up all remaining time
                length = statesTemp[iState].TotalSeconds;
            }
            else
            {
                // use up at least one second of the remaining time, but
                // leave some time for the remaining intervals
                int maxLength = statesTemp[iState].TotalSeconds -
                    intervalCounts[iState];
                length = r.Next( 1, maxLength + 1 );
            }
            // keep track of how much time is left to assign for this state
            statesTemp[iState].TotalSeconds -= length;
            // add a new interval
            Interval interval = new Interval();
            interval.State = states[iState].State;
            interval.Date = next;
            interval.Duration = length;
            result.Add( interval );
            // update the start time for the next interval
            next += new TimeSpan( 0, 0, length );
        }
        return result.ToArray();
    }
