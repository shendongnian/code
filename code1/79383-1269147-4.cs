    using System;
    using System.Collections.Generic;
    using log4net.Appender;
    using log4net.Core;
    
    public class NHibernateQueryAppender : AppenderSkeleton
    {
            private static List<string> s_queries = new List<string>();
    	private static int s_queryCount = 0;
    
    	public static IList<string> CurrentQueries
    	{
    	       get { return s_queries.AsReadOnly(); }
    	}
    
    	public static int CurrentQueryCount
    	{
    		get { return s_queryCount; }
    	}
    
    	public static void Reset()
    	{
    		s_queryCount = 0;
    		s_queries.Clear();
    	}
    		
    	protected override void Append(LoggingEvent loggingEvent)
    	{
    		s_queries.Add(loggingEvent.RenderedMessage);
    		s_queryCount++;
    	}
    }
