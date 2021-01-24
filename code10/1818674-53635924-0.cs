    static void Main(string[] args)
        {
            ObservableCollection<int> array = new ObservableCollection<int>() {4,3,1,5 };
            int steps = 0;
            array.CollectionChanged+= (sender, e) => 
            {
                Console.WriteLine($"{e.Action} : {string.Join(",", array) }" );
                steps++;
            };
            bool didSwap;
            do
            {
                didSwap = false;
                for (int i = 0; i < array.Count - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        didSwap = true;
                    }
                }
            } while (didSwap);
            Console.WriteLine("Sorted Result :");
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total Swapps {steps / 2}");
            
            Console.ReadLine();
        }
