    static void AllRoads(int[] a, int size, int n, RoadContainer VisiKeliai, int[][]map)
            {
                // if size becomes 1 then prints the obtained 
                // permutation 
                if (size == 1)
                    printArr(a, n, VisiKeliai,map);
    
                for (int i = 0; i < size; i++)
                {
                    AllRoads(a, size - 1, n, VisiKeliai,map);
    
                    // if size is odd, swap first and last 
                    // element 
                    if (size % 2 == 1)
                    {
                        int temp = a[0];
                        a[0] = a[size - 1];
                        a[size - 1] = temp;
                    }
    
                    // If size is even, swap ith and last 
                    // element 
                    else
                    {
                        int temp = a[i];
                        a[i] = a[size - 1];
                        a[size - 1] = temp;
                    }
                }
            }
    
            static void printArr(int[] a, int n, RoadContainer VisiKeliai, int[][]map)
            {
                string s = "0";
                // Console.WriteLine("dassaddsasdaasdas"  + a.Length);
                for (int i = 0; i < n; i++)
                {
                    // Console.Write(a[i] + " ");
                    s += Convert.ToString(a[i]);
                }
                s = s.Insert(s.Length, "0");
                Road r = new Road(s);
                CalculatingPrice(r, map);
                VisiKeliai.AddRoad(r);
                //Console.WriteLine(s);
            }
    
            public static void CalculatingPrice(Road Kelias, int[][] map)
            {           
                //  021430 Road im checking
                Console.WriteLine("Kelias: " + Kelias.Path);
                for (int i = 0; i < Kelias.Path.Length - 1; i++)
                {
                    int nextI = i + 1;
                    for (int j = 0; j < 5; j++)
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            string a = Convert.ToString(m);
                            string aaa = Convert.ToString(Kelias.Path[i]);
                            string b = Convert.ToString(j);
                            string bbb = Convert.ToString(Kelias.Path[nextI]);
                            if (a == aaa && b == bbb)
                            {
                                Console.WriteLine(a + "--" + aaa + "---" + b + "----" + bbb + "-------------" + map[j][m]);
                                Kelias.Cost += map[j][m];
                            }
    
                        }
    
                    }
                }
    
            }
