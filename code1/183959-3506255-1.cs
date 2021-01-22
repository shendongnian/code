    Dictionary<String, String> A = new Dictionary<string, string>(); //Example Dictionary
    A.Add("A", "A"); //Example Values
    A.Add("B", "B");
    A.Add("C", "C");
    for (int i = A.Count - 1; i >= 0; i--) //Loop backwards so you can remove elements.
    {
         KeyValuePair<String, String> KeyValue = A.ElementAt(i); //Get current Element.
         if (KeyValue.Value == "B") A.Remove(KeyValue.Key);
    }
