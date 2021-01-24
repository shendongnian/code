    //
    // C# version of code\actions\tools\Calc.java in Chapter 10 of "The Definitive ANTLR 4 Reference"
    //
    
    using System;
    using System.IO;
    using System.Text;
    
    using Antlr4.Runtime;
    
    namespace Calc
    	{
    	class Program
    		{
    		static void Main (string [] Args)
    			{
    			StreamReader  input_src;
    
    			//
    			// If there is a file name on the command line, then use it as the input source; otherwise,
    			// use the console (keyboard) as the input source
    			//
    
    			if (Args.Length > 0)
    				{
    				input_src = File.OpenText (Args [0]);
    				}
    			else
    				{
    				Console.WriteLine ("Enter expressions to evaluate");
    				input_src = new StreamReader (Console.OpenStandardInput (), Console.InputEncoding);
    				}
    
    			//
    			// Read the first line from the input source
    			//
    
    			string				input = input_src.ReadLine ();
    			int					cur_line = 1;											// Needed when parsing lines in a file
    
    			//
    			// Create a parser without a token source. This allows us to instantiate the parser just
    			// once, preserving the @parser::members declared in the grammar. Later, we'll attach the
    			// parser to a token stream
    			//
    
    			ExprParser          parser = new ExprParser (null);
    
    			parser.BuildParseTree = false;
    
    			//
    			// Loop getting input from the input source (console or file) until end of file (or CTRL-Z if input is console)
    			//
    
    			while (input != null)
    				{
    
    				//
    				// The grammar is expecting a NEWLINE as a statement terminator, but that isn't included by ReadLine so add a NEWLINE
    				// to the end of the input string
    				//
    
    				input = input + "\n";
    
    				//
    				// Turn the input string into a stream compatible with ANTLR
    				//
    
    				byte []             input_bytes = Encoding.ASCII.GetBytes (input);
    				MemoryStream        mem_stream = new MemoryStream (input_bytes);
    
    				//
    				// Attach ANTLR to the memory stream
    				//
    
    				AntlrInputStream    input_stream = new AntlrInputStream (mem_stream);   // Create a stream that reads from the input source
    				ExprLexer           lexer = new ExprLexer (input_stream);               // Create a lexer that feeds off of the input stream
    
    				//
    				// When reading from a file the line number is important for error messages. Normally, we would read the entire file into
    				// a string and then parse it, but we're not doing that; we are parsing each line as we read it, so tell the lexer the current
    				// line number and character position before it lexes each input line. If we didn't do this, the error reporting mechanism 
    				// would always report that the error was on line 1
    				//
    
    				lexer.Line = cur_line;
    				lexer.Column = 0;
    
    				CommonTokenStream   tokens = new CommonTokenStream (lexer);             // Create a buffer of tokens pulled from the lexer
    
    				//
    				// Attach the parser to the new token stream (the current line), and start the parse by calling the 'stat' rule in the grammar
    				// The semantic actions will then do all the work of outputting the results from processing the expressions
    				//
    
    				parser.TokenStream = tokens;
    				parser.stat ();
    
    				//
    				// Get the next line of input from the input source
    				//
    
    				input = input_src.ReadLine ();
    				cur_line = cur_line + 1;
    				}   // End while
    
    			}   // End Main
    
    		}   // End class Program
    
    	}   // End namespace Calc
