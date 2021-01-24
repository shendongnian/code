    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class MyInt
    {
        public MyInt(int i)
        {
            Data = i;
        }
        private int _data;
        public int Data
        {
            get => _data;
            set
            {
                if(value<0||value>100)throw new ArgumentOutOfRangeException();
                _data = value;
            }
        }
    }
    public static void Main()
    {
        MyInt[] array = new MyInt[4];
        int min = 0;
        int max = 100;
        for (int count = 0; count < array.Length; count++) // Start the count from 0-4
        {
            Console.WriteLine("Please enter test score " + count);
            try
            {
                array[count] = new MyInt(int.Parse(Console.ReadLine()));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Input exception :{exception}/n, Please input a valid number between {min} and {max}");
                count--;
            }
        }
        Console.WriteLine($"The array result here, eg. Sum of all :{array.Sum(i=>i.Data)}");
        Console.ReadKey();
    }
