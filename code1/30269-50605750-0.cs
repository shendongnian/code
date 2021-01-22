         static int SumOfDigits(int num)
         {
             string stringNum = num.ToString();
             int sum = 0;
             for (int i = 0; i < stringNum.Length; i++)
             {
               sum+= int.Parse(Convert.ToString(stringNum[i]));
             }return sum;
         }
