    //assume an array with given value
    
    int[] arr = { 1, 8, 4, 5, 12, 2, 5, 6, 7, 1, 90, 100, 56, 8, 34 };
    
                int temp, first, second;
                first = second = arr[0];
                foreach (int i in arr)
                {
                    if (first < i)
                    {
                        temp = first;
                        first = i;
                        second = temp;
                    }
                    
                }
                MessageBox.Show(second.ToString());
