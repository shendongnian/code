    public int GenerateRandomNo(Random r)
    {
        int _min = 0000;
        int _max = 9999;
        return r.Next(_min, _max);
    }
    public int rand_num()
    {
        Random rdm = new Random();
        string file_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Invoices\numbers.txt";
        int number = File.ReadLines(file_path).Count(); //count number of lines in file
        System.IO.StreamReader file = new System.IO.StreamReader(file_path);
        if (number == 0)
        {
            randnum = GenerateRandomNo(rdm);
        }
        else
        {
            randnum = GenerateRandomNo(rdm);
            for (int a = 1; a <= number; a++)
            {
                if ((file.ReadLine()) == randnum.ToString())
                    randnum = GenerateRandomNo(rdm);
            }
            file.Close();
        }
        createText = randnum.ToString() + Environment.NewLine;
        File.AppendAllText(file_path, createText);
        file.Close();
        return randnum;
    }
