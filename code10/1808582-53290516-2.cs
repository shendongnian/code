    // No Runs, only text.              
                                
    const String MS = "Microsoft";
    String innerText = sharedString.InnerText;
    if (innerText.IndexOf(MS, StringComparison.OrdinalIgnoreCase) >= 0)
    { 
        sharedString.RemoveAllChildren();
        String[] parts = innerText.Split(' ');
        for (Int32 i = 0; i < parts.Length; i++)
        {
            String part = parts[i];
            Text text = new Text((i > 0 ? " " : String.Empty) + part);
            text.Space = SpaceProcessingModeValues.Preserve;         
            Run run = new Run();                                        
            run.Append(text);
            
            if (part.Equals(MS, StringComparison.OrdinalIgnoreCase))
            {
                run.RunProperties = new RunProperties();
                run.RunProperties.Append(new Color { Rgb = "FFFF0000" }) ;
            }
            sharedString.Append(run);                                        
        }
