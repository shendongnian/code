    Protected Function SanitizeURLString(ByVal RawURLParameter As String) As String
    
          Dim Results As String
    
          Results = RawURLParameter
    
          Results = Results.Replace("<", "%3C")
          Results = Results.Replace(">", "%3E")
          Results = Results.Replace("#", "%23")
          Results = Results.Replace("%", "%25")
          Results = Results.Replace("{", "%7B")
          Results = Results.Replace("}", "%7D")
          Results = Results.Replace("|", "%7C")
          Results = Results.Replace("\", "%5C")
          Results = Results.Replace("^", "%5E")
          Results = Results.Replace("~", "%7E")
          Results = Results.Replace("[", "%5B")
          Results = Results.Replace("]", "%5D")
          Results = Results.Replace("`", "%60")
          Results = Results.Replace(";", "%3B")
          Results = Results.Replace("/", "%2F")
          Results = Results.Replace("?", "%3F")
          Results = Results.Replace(":", "%3A")
          Results = Results.Replace("@", "%40")
          Results = Results.Replace("=", "%3D")
          Results = Results.Replace("&", "%26")
          Results = Results.Replace("$", "%24")
    
          Return Results
    
    End Function
