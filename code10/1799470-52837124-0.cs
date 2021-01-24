    void Spausdinimas(AutomobiliuKonteineris miestai, 
                  string tekstas, 
                  bool stop, 
                  string failas)
    {
      using (StreamWriter writetext = new StreamWriter(failas))
      {
        writetext.WriteLine(tekstas);
        writetext.WriteLine();
        for (int i = 0; i < miestai.Count; i++)
        {
            writetext.WriteLine(miestai.GetCar(i));
        }
        writetext.WriteLine();
      }
    }
