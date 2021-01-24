    //Record data to Hash Table   
    Hashtable hash = new Hashtable();
       
        StreamReader sr = new StreamReader(@"C:\Users\Binh\Desktop\C#\test\exam.txt");
        while(sr.EndOfStream == false)
        {
            string line = sr.ReadLine();
            if(!line.StartsWith("0") && !Regex.IsMatch(line, @"^[A-Z]"))
            {
                string[] info = line.Split(' ');//Split string
                string strudent_id = info[0];
                string student_ans = info[1];
                hash.Add(strudent_id, student_ans);
            }
        }
        sr.Close();
        //Watch the result
        foreach (DictionaryEntry item in hash)
        {
            Console.WriteLine(item.Key + "," + item.Value);
            //OUTPUT:
            //1007,ACBEDADCEBBCDEAABABA
            //1009,BBBBBBBBBBBBBBBBBBBB
            //1010,EEEEEEEEEEEEEEEEEEEE
            //1012,DDDDDDDDDDDDDDDDDDDD
            //1001,BCDEABCDEABCDEABCDEA
            //1002,CDEABCDEABCDEABCDEAB
            //1004,EABCDEABCDEABCDEABCD
            //1006,ABBCCDDEEAABCDEABCDE
            //1008,AAAAAAAAAAAAAAAAAAAA
            //1011,CCCCCCCCCCCCCCCCCCCC
            //1000,ABCDEABCDEABCDEABCDE
            //1003,DEABCDEABCDEABCDEABC
            //1005,AABBCCDDEEABCDEABCDE
        }
