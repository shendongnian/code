    List<string> Data = new List<string>();
    string path = @"C:\Users\manda\Desktop\Schule\Pos1\HüW2Casino\Spieler1.conf"
                
    StreamReader sr = new StreamReader(path);
    StreamWriter sw = new StreamWriter(path);
    
    while ((line=sr.ReadLine()) != null)
    {
       Data.Add(line);
    }
    
    int budget = int.Parse(Data[1].Substring(15, 3));
    
    for (int i = 0; i < Data.Count; i++)
    {
        if (Data[i] != "ENDE")
        {
           numb = rnd.Next(0, 7);
    
           if (Data[i].Substring(0,1) == "0" || Data[i].Substring(0, 1) == "1" || Data[i].Substring(0, 1) == "2" || Data[i].Substring(0, 1) == "3" || Data[i].Substring(0, 1) == "4" || Data[i].Substring(0, 1) == "5" || Data[i].Substring(0, 1) == "6" || Data[i].Substring(0, 1) == "7")
           {
               betnumb = int.Parse(Data[i].Substring(0, 1));
               betamount = int.Parse(Data[i].Split(' ') [1]);
    
               if (betnumb == numb)
               {
                  budget+=betamount*7;
               }
               else
               {
                   budget -= betamount;
               }
               
               if (budget < 0)
               {
                   sw.Write("Pleite");
                   sw.Flush();
                   
                   Console.WriteLine("Pleite");
               }
            }
        }
    }
