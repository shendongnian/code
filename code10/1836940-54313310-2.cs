	public class Ranking : IComparable<Ranking>
	{
      int IComparable<Ranking>.CompareTo( Ranking other )
      {
        var jobFirst = this.JOB_ID.CompareTo( other.JOB_ID );
        return
          jobFirst == 0?
            this.OVERALL_SCORE.CompareTo( other.OVERALL_SCORE ):
            jobFirst;
      } 
    
      //--> other stuff...
      
	}
