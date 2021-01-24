    internal static class ParseResultsExtensions {
        public static IEnumerable<string> GetParameters(this ParseResult p) {
            var pv = new ParameterVisitor();
            p.Script.Accept(pv);
            return pv.Parameters;
        }
    }
<!-->
    string queryString = @"DECLARE @notAParameter INT; SELECT @c, @b, @a, @notAParameter";
    var myParameterCollection = new[] {
        new SqlParameter("@a", SqlDbType.Int),
        new SqlParameter("@b", SqlDbType.Int),
        new SqlParameter("@c", SqlDbType.Int),
    };
    ParseResult parseResults = Parser.Parse(queryString);
    Assert.That(parseResults.Errors, Is.Empty);
    var expected = myParameterCollection.Select(p => p.ParameterName);
    var actual = parseResults.GetParameters();
    Assert.That(actual, Is.EquivalentTo(expected));
