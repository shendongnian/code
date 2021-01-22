     StreamReader SR;
     string S;
     SR = File.OpenText(filename);
     S = SR.ReadLine();
     counter = 1;
     while (S != null)
     {
        if ((counter % 2) != 0)
           Console.WriteLine("Name: " + S);
        else
           Console.WriteLine("Address: " + S);
        S = SR.ReadLine();
        counter++;
     }
     SR.Close();
