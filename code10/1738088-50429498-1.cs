    //
    // C# version of code\actions\tools\Calc.java
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
    			// start reading from the console
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
    
    			string				input = input_src.ReadLine ();
    			int					cur_line = 1;
    
    			//
    			// Create a parser without a token source. This allows us to instantiate the parser just
    			// once, preserving the @parser::members declared in the grammar
    			//
    
    			ExprParser          parser = new ExprParser (null);
    
    			parser.BuildParseTree = false;
    
    			while (input != null)
    				{
    				input = input + "\n";
    				byte []             input_bytes = Encoding.ASCII.GetBytes (input);
    				MemoryStream        mem_stream = new MemoryStream (input_bytes);
    				AntlrInputStream    input_stream = new AntlrInputStream (mem_stream);   // Create a stream that reads from the input source
    				ExprLexer           lexer = new ExprLexer (input_stream);               // Create a lexer that feeds off of the input stream
    
    				lexer.Line = cur_line;
    				lexer.Column = 0;
    
    				CommonTokenStream   tokens = new CommonTokenStream (lexer);             // Create a buffer of tokens pulled from the lexer
    
    				parser.TokenStream = tokens;
    				parser.stat ();
    
    				input = input_src.ReadLine ();
    				cur_line = cur_line + 1;
    				}   // End while
    
    			}   // End Main
    
    		}   // End class Program
    
    	}   // End namespace Calc
