    private Random _rdm = new Random();
    public int GenerateRandomNo()
    {
        int _min = 0000;
        int _max = 9999;
        return _rdm.Next(_min, _max);
    }
    public int rand_num()
    {
      string file_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Invoices\numbers.txt";
      int randnum = 0;
      string line = "";
      if (File.Exists(file_path)) {
        while(randnum==0)
        {
          randnum = GenerateRandomNo();
          using (System.IO.StreamReader file = new System.IO.StreamReader(file_path)) {
            while ((line = sr.ReadLine()) != null)
            {
               if (line == randnum.ToString()) {
                 randnum = 0;
                 break;
               }
            }
          }
          file.Close();
        }
      
        createText = randnum.ToString() + Environment.NewLine;
        File.AppendAllText(file_path, createText);
        file.Close();
        return randnum;
      } else {
        randnum = GenerateRandomNo();
        createText = randnum.ToString() + Environment.NewLine;
        File.WriteAllText(file_path, createText);
        file.Close();
      }
    }
