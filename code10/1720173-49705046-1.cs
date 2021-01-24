    static void Main(string[] args)
        {
            List<string> outputList = new List<string>();
            string[] list = new string[] { "85 - 0521031, Shampoo, 35, 9, 0, 0, 2.89", "86 - 0521031, Guitar, 35, 9, 0, 0, 9.89" };
            for(var i=0; i<list.Length; i++)
            {
                var listItem = list[i].Split(',');
                var outputListItem = "";
                for (var j=0; j<listItem.Length; j++)
                {
                    if(j == 6)
                    {
                        double price = double.Parse(listItem[j]);
                        listItem[j] = String.Format("{0:C2}", price).PadRight(20, ' '); ;
                    }
                    outputListItem = string.Join(" ", listItem);
                }
                Console.WriteLine(outputListItem);
                outputList.Add(outputListItem);
            }
            Console.ReadLine();
        }
