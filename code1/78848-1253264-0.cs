    private static void TestMethod()
        {
            foreach (States state in EnumToList<States>())
            {
                Console.Write(GetEnumDescription(state) + "\t");
                Int32 index = ((Int32)state);
                Console.Write(index.ToString() + "\t");
                States tempState = (States)index;
                Console.WriteLine(tempState.ToString());
            }
            Console.ReadLine();
        }
