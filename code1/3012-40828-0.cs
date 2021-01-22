	class MyNoViableAltException : Exception
	{
		public MyNoViableAltException()
		{
		}
		public MyNoViableAltException(string grammarDecisionDescription, int decisionNumber, int stateNumber, Antlr.Runtime.IIntStream input)
		{
		}
	}
	class MyEarlyExitException : Exception
	{
		public MyEarlyExitException()
		{
		}
		public MyEarlyExitException(int decisionNumber, Antlr.Runtime.IIntStream input)
		{
		}
	}
