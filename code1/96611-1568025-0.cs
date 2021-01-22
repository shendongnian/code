    using System.Text.RegularExpressions;
    
    // ...
    
    string unwanted = @"["";:'.,=+!@#$%^&*(_)~{}\[\]\\|<>? aeiouAEIOU]";
    
    string subject = "The quick brown fox jumped over the lazy dog.";
    
    string result = Regex.Replace(subject, unwanted, string.Empty);
    // Thqckbrwnfxjmpdvrthlzydg
