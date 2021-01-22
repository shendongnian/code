    XPathDocument doc = new XPathDocument("sample.xml");
    var navigator = doc.CreateNavigator();
    var iterator = navigator.Select("/questionnaire/quest");
    while (iterator.MoveNext())
    {
    	Console.WriteLine("=================================");
    
    	Console.WriteLine("ID : " + iterator.Current.GetAttribute("ord", String.Empty));
    	var intro = iterator.Current.Select("intro/t");
    	if (intro.MoveNext())
    	{
    		Console.WriteLine("TEXTE : " + intro.Current.Value);
    	}
    
    	var response1 = iterator.Current.Select("rep1/t");
    	if (response1.MoveNext())
    	{
    		Console.WriteLine("REPONSE1 : " + response1.Current.Value);
    	}
    
    	var cle1 = iterator.Current.Select("rep1/ev/@id");
    	if (cle1.MoveNext())
    	{
    		Console.WriteLine("CLE1 : " + cle1.Current.Value);
    	}
    
    	var response2 = iterator.Current.Select("rep2/t");
    	if (response2.MoveNext())
    	{
    		Console.WriteLine("REPONSE2 : " + response2.Current.Value);
    	}
    
    	var cle2 = iterator.Current.Select("rep2/ev/@id");
    	if (cle2.MoveNext())
    	{
    		Console.WriteLine("CLE2 : " + cle2.Current.Value);
    	}
    
    	Console.WriteLine("ETAT : False");
    }
