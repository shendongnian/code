    Microsoft (R) Visual C# Interactive Compiler version 1.2.0.60317
    Copyright (C) Microsoft Corporation. All rights reserved.
    
    Type "#help" for more information.
    > using System.Text.RegularExpressions;
    > var str = @"Normal Text is here
    . More normal text
    . -- Commented text
    . -- More commented text
    . Normal Text again
    . --Commented Text Again";
    > str = Regex.Replace(str, @"^--\s*", string.Empty, RegexOptions.Multiline);
    > Console.WriteLine(str);
    Normal Text is here
    More normal text
    Commented text
    More commented text
    Normal Text again
    Commented Text Again
