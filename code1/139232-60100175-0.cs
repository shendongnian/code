     int sum = 0,missingNumber;
            int[] arr = { 1,2,3,4,5,6,7,8,9};
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("The sum from 1 to 10 is 55");
            Console.WriteLine("Sum is :" +sum);
            missingNumber =  55 - sum;
            Console.WriteLine("Missing Number is :-"+missingNumber);
            Console.ReadLine();
