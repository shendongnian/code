     static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)  
        {  
          Console.WriteLine("Speech recognized:  " + e.Result.Text);  
          Console.WriteLine();  
          Console.WriteLine("Semantic results:");  
          Console.WriteLine("  The flight origin is " + e.Result.Semantics["origin"].Value);  
          Console.WriteLine("  The flight destination is " + e.Result.Semantics["destination"].Value);  
        }  
