        enum clientHeader { Id_Client, Name, Type, Description, Name_CLient, Surname, Id_Spelciaty, Final_add, State };
        enum appointHeader { Id_Appoint, Name_Client, Surname, Type_Appoint, Date, Description, Id_Client, Final_add, State };
        struct MenuHistoricArgument
        {
            public string[,] animal, client, vet, appointment, obsRooms, typeAnimal, spelciaty;
        }
        static void Main (string[] args)
        {
            Console.SetWindowSize(146, 45);
            MenuHistoricArgument menuArgs = new MenuHistoricArgument()
            {
                animal = new string[30, 9],
                client = new string[30, 9],
                vet = new string[30, 9],
                appointment = new string[30, 9],
                obsRooms = new string[30, 5],
                typeAnimal = new string[30, 5],
                spelciaty = new string[30, 5],
            };
            do {
                menuHistoric(menuArgs);
            } while (true);
        }
        static void showHeader<T> (string[,] matrix)
        {
            int x = matrix.GetUpperBound(1), width = (tableWidth / x);
            Console.Clear();
            Console.WriteLine("\n");
            PrintLine();
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                Console.Write((GetHeader<T>(i)?.Length > width) ? $"{GetHeader<T>(i)?.Substring(0, width - 3) + ".." + "|".ToUpper()}" : $"{ GetHeader<T>(i)?.PadRight(width - (width - GetHeader<T>(i).Length) / 2).PadLeft(width).ToUpper()}|");
            }
            Console.WriteLine();
            PrintLine();
        }
        static int tableWidth = 143;
        static void PrintLine ()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        static void menuHistoric (MenuHistoricArgument menuArgs)
        {
            while (true)
            {
                int optHist;
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nInsert:\n\t[ 1 ] Visualize historic Clients");
                    Console.Write("\t[ 2 ] Visualize historic Appointments ");
                } while (!int.TryParse(Console.ReadLine(), out optHist) || optHist < 0 || optHist > 7);
                Console.Clear();
                bool goBack = false;
                switch (optHist)
                {
                    case 1:
                        showHeader<clientHeader>(menuArgs.client);
                        menuReturn();
                        break;
                    case 2:
                        showHeader<appointHeader>(menuArgs.appointment);
                        menuReturn();
                        break;
                    case 0:
                        goBack = true;
                        break;
                }
                if (goBack) return;
            }
        }
        static void menuReturn ()
        {
            Console.ReadKey();
            Console.Clear();
        }
        private static string GetHeader<T> (int i) => Enum.GetName(typeof(T), i);
