            static void Main( string[] args ) {
                Console.WriteLine(string.Join(", ", getArray(new int[] { 1, 2, 3, 4, 5 })));
                Console.Read();
                return;
            }
            static int[] getArray( int[] arr ) {
                List<int> O = new List<int>();
                for (int x = 1, l = arr.Length; x < l; x++) {
                    O.Add(arr[x]);
                }
                O.Add(arr[0]);
                return O.ToArray();
            }
