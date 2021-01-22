    String email = "bar@foo.com;foo#bar.com";
    
    String expression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
    
    Regex regex = new Regex(expression);
    
    String[] emails = email.Split(new Char[] { ';' });
    
    foreach (String s in emails)
    {
    
    	Match m = regex.Match(s);
    
    	if (!m.Success)
         {
         	// Validation fails.
              
         }
    }
