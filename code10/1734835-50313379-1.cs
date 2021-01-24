    void MyMethod()
    {
        int a;
        try
        {
            Console.Write("Input = ");
            a = Convert.ToInt32(Console.ReadLine());
            if (a < 0)
            {
                throw new MyException("Input Can't < 0");
            }
        }
        catch (MyException myEx)
        {
            Console.WriteLine("MyException was thrown");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Some other exception was thrown");
        }
        Console.ReadKey();
    }
