        public static void LoopOverEnum(Type type)
            int k = 0;
            foreach (var item in Enum.GetValues(type))
            {
                Console.Write($"{k} ");
                Console.Write(item);
                Console.WriteLine();
                k++;
            }
        }
        // usage:
        LoopOverEnum(typeof(Main_menu))
