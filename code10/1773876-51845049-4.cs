                static void Main(string[] args)
                {
                            int[] array = new int[4] { 73, 67, 38, 33 };
                            int[] newarr = array.Select(arrayvalue => arrayvalue * 2).ToArray();
                }
