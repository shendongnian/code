        public static void LoopOverEnum<T>()
            int k = 0;
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                Console.Write($"{k} ");
                Console.Write(item);
                Console.WriteLine();
                k++;
            }
        }
        // usage:
        LoopOverEnum<Main_menu>()
