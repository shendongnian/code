    StreamWriter sw = new StreamWriter("c:\\output.txt");
            StreamReader sr = new StreamReader("c:\\input.txt");
            string inputLine = "";
    
            while ((inputLine = sr.ReadLine()) != null)
            {
                String[] values = null;
                values = inputLine.Split('^');
                sw.WriteLine("{0}^{1}^{2}", values[1], values[0], values[2]);
            }
            sr.Close();
            sw.Close();
