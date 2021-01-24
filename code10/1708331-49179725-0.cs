	   static void Main(string[] args)
        {
            var sqlText = @"
             create procedure something
                as
	                select 100;
	                select 200
	                exec sp_who2;              
            ";
            var sql = new StringReader(sqlText);
            var parser = new TSql140Parser(false);
            IList<ParseError> errors;
            var script = parser.Parse(sql, out errors);
            var visitor = new visitor();
            script.Accept(visitor);
            TSqlParserToken startComment = new TSqlParserToken(TSqlTokenType.SingleLineComment, "/*");
            TSqlParserToken endComment = new TSqlParserToken(TSqlTokenType.SingleLineComment, "*/");
            var newScriptSql = "";
            for (var i = 0; i < script.LastTokenIndex; i++)
            {
                if (i == visitor.Statement.FirstTokenIndex)
                {
                    newScriptSql += startComment.Text;
                }
                if (i == visitor.Statement.LastTokenIndex)
                {
                    newScriptSql += endComment.Text;
                }
                newScriptSql += script.ScriptTokenStream[i].Text;
            }
            script = parser.Parse(new StringReader(newScriptSql), out errors);
            Console.WriteLine(newScriptSql);
        }
        class visitor : TSqlFragmentVisitor
        {
            public ExecuteStatement Statement;
            public override void Visit(ExecuteStatement s)
            {
                Statement = s;
            }
        }
    }
