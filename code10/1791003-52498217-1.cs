            using (var sw = new StreamWriter(@"C:\Users\Computer\Desktop\byte.txt"))
            {
                sw.WriteLine(int.Parse(Console.ReadLine()));
                sw.WriteLine(double.Parse(Console.ReadLine()));
                sw.WriteLine(Console.ReadLine());
            }
            using (var sr = new StreamReader(@"C:\Users\Computer\Desktop\byte.txt"))
            {
               int a =  int.Parse(sr.ReadLine());
               double b =  double.Parse(sr.ReadLine());
               string c =  sr.ReadLine();
            } 
