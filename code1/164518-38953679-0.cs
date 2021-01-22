	public delegate object Acceptor(Token token, string match);
	
	public class Symbol
	{
	    public Symbol(string id) { Id = id ?? Guid.NewGuid().ToString("P"); }
	    public override string ToString() => Id;
	    public string Id { get; private set; }
	}
	
	public class Token : Symbol
	{
	    internal Token(string id) : base(id) { }
	    public Token(string pattern, Acceptor acceptor) : base(pattern) { Regex = new Regex(string.Format("^({0})", !string.IsNullOrEmpty(Pattern = pattern) ? Pattern : ".*"), RegexOptions.Compiled); ValueOf = acceptor; }
	    public string Pattern { get; private set; }
	    public Regex Regex { get; private set; }
	    public Acceptor ValueOf { get; private set; }
	}
	
	public class SExpressionSyntax
	{
	    private readonly Token Space = Token("\\s+", Echo);
	    private readonly Token Open = Token("\\(", Echo);
	    private readonly Token Close = Token("\\)", Echo);
	    private readonly Token Quote = Token("\\'", Echo);
	    private Token comment;
	
	    private static Exception Error(string message, params object[] arguments) => new Exception(string.Format(message, arguments));
	
	    private static object Echo(Token token, string match) => new Token(token.Id);
	
	    private static object Quoting(Token token, string match) => NewSymbol(token, match);
	
	    private Tuple<Token, string, object> Read(ref string input)
	    {
	        if (!string.IsNullOrEmpty(input))
	        {
	            var found = null as Match;
	            var sofar = input;
	            var tuple = Lexicon.FirstOrDefault(current => (found = current.Item2.Regex.Match(sofar)).Success && (found.Length > 0));
	            var token = tuple != null ? tuple.Item2 : null;
	            var match = token != null ? found.Value : null;
	            input = match != null ? input.Substring(match.Length) : input;
	            return token != null ? Tuple.Create(token, match, token.ValueOf(token, match)) : null;
	        }
	        return null;
	    }
	
	    private Tuple<Token, string, object> Next(ref string input)
	    {
	        Tuple<Token, string, object> read;
	        while (((read = Read(ref input)) != null) && ((read.Item1 == Comment) || (read.Item1 == Space))) ;
	        return read;
	    }
	
	    public object Parse(ref string input, Tuple<Token, string, object> next)
	    {
	        var value = null as object;
	        if (next != null)
	        {
	            var token = next.Item1;
	            if (token == Open)
	            {
	                var list = new List<object>();
	                while (((next = Next(ref input)) != null) && (next.Item1 != Close))
	                {
	                    list.Add(Parse(ref input, next));
	                }
	                if (next == null)
	                {
	                    throw Error("unexpected EOF");
	                }
	                value = list.ToArray();
	            }
	            else if (token == Quote)
	            {
	                var quote = next.Item3;
	                next = Next(ref input);
	                value = new[] { quote, Parse(ref input, next) };
	            }
	            else
	            {
	                value = next.Item3;
	            }
	        }
	        else
	        {
	            throw Error("unexpected EOF");
	        }
	        return value;
	    }
	
	    protected Token TokenOf(Acceptor acceptor)
	    {
	        var found = Lexicon.FirstOrDefault(pair => pair.Item2.ValueOf == acceptor);
	        var token = found != null ? found.Item2 : null;
	        if ((token == null) && (acceptor != Commenting))
	        {
	            throw Error("missing required token definition: {0}", acceptor.Method.Name);
	        }
	        return token;
	    }
	
	    protected IList<Tuple<string, Token>> Lexicon { get; private set; }
	
	    protected Token Comment { get { return comment = comment ?? TokenOf(Commenting); } }
	
	    public static Token Token(string pattern, Acceptor acceptor) => new Token(pattern, acceptor);
	
	    public static object Commenting(Token token, string match) => Echo(token, match);
	
	    public static object NewSymbol(Token token, string match) => new Symbol(match);
	
	    public static Symbol Symbol(object value) => value as Symbol;
	
	    public static string Moniker(object value) => Symbol(value) != null ? Symbol(value).Id : null;
	
	    public static string ToString(object value)
	    {
	        return
	            value is object[] ?
	            (
	                ((object[])value).Length > 0 ?
	                ((object[])value).Aggregate(new StringBuilder("("), (result, obj) => result.AppendFormat(" {0}", ToString(obj))).Append(" )").ToString()
	                :
	                "( )"
	            )
	            :
	            (value != null ? (value is string ? string.Concat('"', (string)value, '"') : (value is bool ? value.ToString().ToLower() : value.ToString())).Replace("\\\r\n", "\r\n").Replace("\\\n", "\n").Replace("\\t", "\t").Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\\"", "\"") : null) ?? "(null)";
	    }
	
	    public SExpressionSyntax()
	    {
	        Lexicon = new List<Tuple<string, Token>>();
	        Include(Space, Open, Close, Quote);
	    }
	
	    public SExpressionSyntax Include(params Token[] tokens)
	    {
	        foreach (var token in tokens)
	        {
	            Lexicon.Add(new Tuple<string, Token>(token.Id, token));
	        }
	        return this;
	    }
	
	    public object Parse(string input)
	    {
	        var next = Next(ref input);
	        var value = Parse(ref input, next);
	        if ((next = Next(ref input)) != null)
	        {
	            throw Error("unexpected ", next.Item1);
	        }
	        return value;
	    }
	}
	
	public class CustomSExpressionSyntax : SExpressionSyntax
	{
	    public CustomSExpressionSyntax()
	        : base()
	    {
	        Include
	        (
	            // "//" comments
	            Token("\\/\\/.*", SExpressionSyntax.Commenting),
	
	            // Obvious
	            Token("false", (token, match) => false),
	            Token("true", (token, match) => true),
	            Token("null", (token, match) => null),
	            Token("\\-?[0-9]+\\.[0-9]+", (token, match) => double.Parse(match)),
	            Token("\\-?[0-9]+", (token, match) => int.Parse(match)),
	
	            // String literals
	            Token("\\\"(\\\\\\n|\\\\t|\\\\n|\\\\r|\\\\\\\"|[^\\\"])*\\\"", (token, match) => match.Substring(1, match.Length - 2)),
	
	            // Identifiers
	            Token("[_A-Za-z][_0-9A-Za-z]*", NewSymbol)
	        );
	    }
	}
	
	public class Node { }
	
	public class HearPerceptorState : Node
	{
	    public string Ident { get; set; }
	    public double Value { get; set; }
	}
	
	public class HingeJointState : Node
	{
	    public string Ident { get; set; }
	    public double Value { get; set; }
	}
	
	public class Polar : Tuple<double, double, double>
	{
	    public Polar(double a, double b, double c) : base(a, b, c) { }
	}
	
	public class ForceResistancePerceptorState : Node
	{
	    public string Ident { get; set; }
	    public Polar Polar { get; set; }
	}
	
	public class Test
	{
	    public static void Main()
	    {
	        var input = @"
	            (
	                (Hear 12.3 HelloWorld)
	                (HJ LAJ1 -0.42)
	                (FRP lf (pos 2.3 1.7 0.4))
	            )
	        ";
	
	        // visit DRY helpers
	        Func<object, object[]> asRecord = value => (object[])value;
	        Func<object, Symbol> symbol = value => SExpressionSyntax.Symbol(value);
	        Func<object, string> identifier = value => symbol(value).Id;
	
	        // the SExpr visit, proper
	        Func<object[], Node[]> visitAll = null;
	        Func<object[], Node> visitHear = null;
	        Func<object[], Node> visitHJ = null;
	        Func<object[], Node> visitFRP = null;
	
	        visitAll =
	            all =>
	                all.
	                Select
	                (
	                    item =>
	                        symbol(asRecord(item)[0]).Id != "Hear" ?
	                        (
	                            symbol(asRecord(item)[0]).Id != "HJ" ?
	                            visitFRP(asRecord(item))
	                            :
	                            visitHJ(asRecord(item))
	                        )
	                        :
	                        visitHear(asRecord(item))
	                ).
	                ToArray();
	
	        visitHear =
	            item =>
	                new HearPerceptorState { Value = (double)asRecord(item)[1], Ident = identifier(asRecord(item)[2]) };
	
	        visitHJ =
	            item =>
	                new HingeJointState { Ident = identifier(asRecord(item)[1]), Value = (double)asRecord(item)[2] };
	
	        visitFRP =
	            item =>
	                new ForceResistancePerceptorState
	                {
	                    Ident = identifier(asRecord(item)[1]),
	                    Polar =
	                        new Polar
	                        (
	                            (double)asRecord(asRecord(item)[2])[1],
	                            (double)asRecord(asRecord(item)[2])[2],
	                            (double)asRecord(asRecord(item)[2])[3]
	                        )
	                };
	
	        var syntax = new CustomSExpressionSyntax();
	
	        var sexpr = syntax.Parse(input);
	
	        var nodes = visitAll(asRecord(sexpr));
	
	        Console.WriteLine("SO_3051254");
	        Console.WriteLine();
	        Console.WriteLine(nodes.Length == 3);
	        Console.WriteLine(nodes[0] is HearPerceptorState);
	        Console.WriteLine(nodes[1] is HingeJointState);
	        Console.WriteLine(nodes[2] is ForceResistancePerceptorState);
	    }
	}
