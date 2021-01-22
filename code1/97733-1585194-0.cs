    public void TossCoin()
    {
        string[] sides = { "Head", "Tail" };
        var outcome = from first in sides 
                      from second in sides
                      from third in sides
                      from fourth in sides 
                      select first + "," + second + "," + third + "," + fourth;
    
        foreach (string oc in outcome)
        {
            Console.WriteLine(oc);
        }
    }
