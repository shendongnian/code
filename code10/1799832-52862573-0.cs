    String GetBestMove(String forsythEdwardsNotationString){
        var p = new System.Diagnostics.Process();
        p.StartInfo.FileName = "stockfishExecutable";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();  
        String setupString = "position fen "+forsythEdwardsNotationString;
        p.StandardInput.WriteLine(setupString);
        
        // Process for 5 seconds
        String processString = "go movetime 5000";
        
        // Process 20 deep
        // String processString = "go depth 20";
    
        p.StandardInput.WriteLine(processString);
        
        String bestMoveInAlgebraicNotation = p.StandardOutput.ReadLine();
    
        p.Close();
    
        return bestMoveInAlgebraicNotation;
    }
