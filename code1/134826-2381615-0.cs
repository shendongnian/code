    using System;
    using System.Text;
    
    public class ArrayReindexer
    {
    	private Array reindexed;
    	private int location, offset;
    
    	public ArrayReindexer( Array source )
    	{
    		reindexed = source;
    	}
    
    	public object this[int index]
    	{
    		get
    		{
    			if (offset > 0 && index >= location)
    			{
    				int adjustedIndex = index + offset;
    				return adjustedIndex >= reindexed.Length ? "null" : reindexed.GetValue( adjustedIndex );
    			}
    
    			return reindexed.GetValue( index );
    		}
    	}
    
    	public void Reindex( int position, int shiftAmount )
    	{
    		location = position;
    		offset = shiftAmount;
    	}
    
    	public override string ToString()
    	{
    		StringBuilder output = new StringBuilder( "[ " );
    		for (int i = 0; i < reindexed.Length; ++i)
    		{
    			output.Append( this[i] );
    			if (i == reindexed.Length - 1)
    			{
    				output.Append( " ]" );
    			}
    			else
    			{
    				output.Append( ", " );
    			}
    		}
    
    		return output.ToString();
    	}
    }
