    public static List<string> Calculate(List<string> strings) {
                List<string> returnValue = new List<string>();
                int[] numbers = new int[strings.Count];
                for (int x = 0; x < strings.Count; x++) {
                    numbers[x] = 0;
                }
                while (true) {
                    StringBuilder value = new StringBuilder();
                    for (int x = 0; x < strings.Count; x++) {
                        value.Append(strings[x][numbers[x]]);
                        //int absd = numbers[x];
                    }
                    returnValue.Add(value.ToString());
                    numbers[0]++;
                    for (int x = 0; x < strings.Count-1; x++) {
                        if (numbers[x] == strings[x].Length) {
                            numbers[x] = 0;
                            numbers[x + 1] += 1;
                        }
                    }
                    if (numbers[strings.Count-1] == strings[strings.Count-1].Length)
                        break;
                    
                }
                return returnValue;
            }
