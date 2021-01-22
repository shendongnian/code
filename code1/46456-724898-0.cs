    string str = "47-61-74-65-77-61-79-53-65-72-76-65-72";
    string[] parts = str.Split('-');
    foreach (string val in parts)
    { 
        int x;
        if (int.TryParse(val, out x))
        {
             Console.Write(string.Format("{0:x2} ", x);
        }
    }
    Console.WriteLine();
