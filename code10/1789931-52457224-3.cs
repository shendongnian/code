    const string Path = @"C:\Users\manda\Desktop\Schule\Pos1\HüW2Casino\Spieler1.conf";
    string[] data = File.ReadAllLines(Path);
    int budget = Int32.Parse(data[1].Substring(15, 3));
    using (StreamWriter sw = File.AppendText(Path)) {
        for (int i = 0; i < data.Length && data[i] != "ENDE"; i++) {
            numb = rnd.Next(0, 7);
            char digit = data[i][0]; // Take the 1st char instead of Substring(0,1).
            if ('0' <= digit && digit <= '7') { // Chars can be compared like numbers.
                betnumb = digit - '0'; // You can do math on chars.
                betamount = Int32.Parse(data[i].Split(' ')[1]);
                if (betnumb == numb) {
                    budget += betamount * 7;
                } else {
                    budget -= betamount;
                }
                if (budget < 0) {
                    sw.Write("Pleite");
                    Console.WriteLine("Pleite"); // German for "bankrupt".
                    break; // Probably you don't want to continue looping when bankrupt.
                }
            }
        }
    } // Automatically flushes and closes the file here.
