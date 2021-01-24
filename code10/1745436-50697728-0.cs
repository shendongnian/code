    using System;
    
    namespace Solutions
    {
        using System.Text.RegularExpressions;
    
        class Program
        {
            static void Main()
            {
                const string RedirectUrl = "https://www.example.com/cb#access_token=bHLgV4q6--&token_type=bearer&xoauth_yahoo_guid=JTDI2OCE&state=XYZ";
    
                // Create Uri
                var uriAddress = new Uri(RedirectUrl);
    
                if (string.IsNullOrEmpty(uriAddress.Fragment))
                {
                    Console.WriteLine("Null Fragment");
                    return;
                }
                Console.WriteLine(uriAddress.Fragment);
    
                // To get complete appended Access code
                Console.WriteLine(uriAddress.Fragment.Substring(uriAddress.Fragment.IndexOf("#", StringComparison.CurrentCultureIgnoreCase)));
    
                // Apply Regex to get matches
                var regex = new Regex("([^?=&]+)(=([^&]*))?");
                var matches = regex.Matches(uriAddress.Fragment);
                foreach (Match match in matches)
                {
                    var keyValueSplit = match.Value.Split(new[] { '=' }, 2, StringSplitOptions.None);
                    Console.WriteLine(keyValueSplit[0] + " = " + keyValueSplit[1]);
                }
                
                Console.ReadLine();
            }
        }
    }
