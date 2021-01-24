        public static void BoxMaker(int height, int width)
        {
            int num = 1;
            string box = "";
            while (num <= height)
            {
                if (num == 1 || num == height)
                {
                    for (int i = 1; i <= width; i++)
                    {
                        box += "*";
                        if (i == width) box += "\r\n";
                    }
                }
                else
                {
                    int num2 = 1;
                    while (num2 <= width)
                    {
                        if (num2 == 1 || num2 == width)
                        {
                            box += "*";
                            if (num2 == width) box += "\r\n";
                        }
                        else
                        {
                            box += " ";
                        }
                        num2++;
                    }
                }
                num++;
            }
            Console.Write(box);
            Console.ReadKey();
        }
