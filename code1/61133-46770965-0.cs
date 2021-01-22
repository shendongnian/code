       using System.Collections;
    
    ICollection keyCollections = dict.Keys;
    ICOllection valueCollections = dict.Values;
    
    String[] myKeys = new String[dict.Count];
    String[] myValues = new String[dict.Count];
    
    keyCollections.CopyTo(myKeys,0);
    valueCollections.CopyTo(myValues,0);
    
    for(int i=0; i<dict.Count; i++)
    {
    Console.WriteLine("Key: " + myKeys[i] + "Value: " + myValues[i]);
    }
    Console.ReadKey();
