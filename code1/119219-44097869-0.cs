    int reverseNum = 0, reminder, num;
            Console.WriteLine("Enter Number to Reverse:");
            int.TryParse(Console.ReadLine(), out num);
            bool isZero = false;
            int cnt=0;
            while (num > 0)
            {
                reminder = num % 10;
                reverseNum = (reverseNum * 10) + reminder;
                num = num / 10;
                if (reverseNum == 0)
                    isZero = true;                
                cnt++;
            }
            if (isZero)
            {
                Console.WriteLine(reverseNum.ToString().PadLeft(cnt, '0'));
            }
            else
            {
                Console.WriteLine(reverseNum);
            }
            Console.ReadKey();
