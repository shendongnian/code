    public static int CharToInt(char input)
    {
        int result = -1;
        if (input >= 48 && input <= 57)
        {
            result = input - '0';
        }
        return result;
    }
    static void Main(string[] args)
    {
        int soma = 0;
        while (soma < 20)
        {
            Console.WriteLine("Soma is:" + soma);
            string numero = Console.In.ReadLine();
            foreach (char num in numero)
            {
                int value = CharToInt(num);
                soma += value;
            }
        }
        Console.WriteLine("Final Soma is:" + soma);
    }
