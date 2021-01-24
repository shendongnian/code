	class Program
	{
		static void Main(string[] args)
		{
			var sqlText = @"
	create procedure something
	as
		select 100;
		select 200
		exec sp_who;              
		exec sp_who2;              
	";
			var sql = new StringReader(sqlText);
			var parser = new TSql140Parser(false);
			var script = parser.Parse(sql, out IList<ParseError> errors);
			var visitor = new ExecVisitor();
			script.Accept(visitor);
			TSqlParserToken startComment = new TSqlParserToken(TSqlTokenType.SingleLineComment, "/*");
			TSqlParserToken endComment = new TSqlParserToken(TSqlTokenType.SingleLineComment, "*/");
			var newScriptTokenStream = new List<TSqlParserToken>(script.ScriptTokenStream);
			for(var i = visitor.Statements.Count - 1; i >= 0; i--)
			{
				var stmt = visitor.Statements[i];
				newScriptTokenStream.Insert(stmt.LastTokenIndex, endComment);
				newScriptTokenStream.Insert(stmt.FirstTokenIndex, startComment);
			}
			var newFragment = parser.Parse(newScriptTokenStream, out errors);
			Console.WriteLine(GetScript(newFragment.ScriptTokenStream));
		}
		private static string GetScript(IList<TSqlParserToken> tokenStream)
		{
			var sb = new StringBuilder();
			foreach(var t in tokenStream)
			{
				sb.Append(t.Text);
			}
			return sb.ToString();
		}
	}
	class ExecVisitor : TSqlFragmentVisitor
	{
		public IList<ExecuteStatement> Statements { get; set; } = new List<ExecuteStatement>();
		public override void Visit(ExecuteStatement s)
		{
			Statements.Add(s);
		}
	}
