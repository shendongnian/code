       using(System.IO.StreamReader sr = new System.IO.StreamReader("F:/C#/graph/graph/bin/Debug/x.txt"))
        {
            string line;
            while((line = sr.ReadLine()) != null)
            {
                string[] x = line.Split(' ');
            }
        }
       using(System.IO.StreamReader sr = new System.IO.StreamReader("F:/C#/graph/graph/bin/Debug/y.txt"))
        {
            string line;
            while((line = sr.ReadLine()) != null)
            {
                string[] yString = line.Split(' ');
            }
            int[] y = Array.ConvertAll(yString , s => int.Parse(s));
        }
