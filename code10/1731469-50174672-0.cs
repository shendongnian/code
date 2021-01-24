            var list = new int[] {5,7,0,2}; //array
            bool alert = true;
            while (alert == true)
            {
                alert = false;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    while (list[i] > list[i + 1])
                    {
                        int temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        alert = true;
                    }
                }
            }
            Console.WriteLine(string.Join(",", list));
            Console.ReadKey();
