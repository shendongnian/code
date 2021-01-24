    1:  1  2  3 |  4  5  6 |  7  8  9 | 10 11 12 | 13 14 15 | 16 17 18 | 19 20 21
    2:  8 12 21 | 20 17  7 |  2 11 15 |  1 16 10 |  4  9 19 | 13  3  5 | 18  6 14
    3: 20  2 18 |  5 12 14 |  8 16  4 | 10  7 21 |  6  1 19 |  3 15 17 | 11 13  9
    4: 12  9  2 |  5  8 11 |  1 13 17 | 19 10 18 |  3 20 16 |  4 14  7 | 21  6 15
    5:  7 19  5 | 14  1  8 | 15 12 20 | 21 16 11 | 17 10  4 | 18  3  9 | 13  2  6
    6: 18  8 15 | 13 12  7 |  2 10  5 |  6 11 17 | 19 16 14 | 20  1  9 |  4 21  3
    class Program
    {
        static Random random = new Random();
        static int students = 21;
        static int studentsPerGroup = 3;
        static int groups = students / studentsPerGroup;
        static List<int[]> history = new List<int[]>();
    
        static void Main(string[] args)
        {
            int[] order = Enumerable.Range(1, students).ToArray();
            int round = 1;
    
            history.Add(order);
            showOrder(round, order);
    
            while (++round < 500)
            {
                do
                {
                    order = shuffle(ref order);
                }
                while (!allowed(ref order));
    
                history.Add(order);
                showOrder(round, order);
            }
    
            Console.WriteLine("ciao!");
    
        }
    
        private static bool allowed(ref int[] order)
        {
            for (int g = 0; g < groups; g++)
                for (int i = 0; i < studentsPerGroup - 1; i++)
                    for (int j = i + 1; j < studentsPerGroup; j++)
                    {
                        int student1 = order[g * studentsPerGroup + i];
                        int student2 = order[g * studentsPerGroup + j];
    
                        foreach (var ord in history)
                        {
                            int g1 = 0;
                            int g2 = 0;
    
                            for (int k = 0; k < students; k++)
                                if (ord[k] == student1)
                                {
                                    g1 = k / studentsPerGroup;
                                    break;
                                }
                            for (int k = 0; k < students; k++)
                                if (ord[k] == student2)
                                {
                                    g2 = k / studentsPerGroup;
                                    break;
                                }
                            if (g1 == g2)
                            {
                                return false;
                            }
                        }
                    }
    
            return true;
        }
    
        static void showOrder(int n, int[] order)
        {
            string s = string.Format("{0,4}:", n);
            int i = 0;
    
            foreach(var st in order)
            {
                s += string.Format(" {0,2}", st);
                if (++i % studentsPerGroup == 0)
                {
                    s += " |";
                }
            }
    
            Console.WriteLine(s);
        }
    
        static int[] shuffle(ref int[] arr)
        {
            return arr.OrderBy(i => random.Next()).ToArray();
        }
    }
