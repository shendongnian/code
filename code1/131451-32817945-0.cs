        System.Collections.ArrayList mixedList = new System.Collections.ArrayList();
        // Add some numbers to the list
        mixedList.Add(7);
        mixedList.Add(21);
        // Add some strings to the list
        mixedList.Add("Hello");
        mixedList.Add("This is going to be a problem");
        System.Collections.ArrayList intList = new System.Collections.ArrayList();
        System.Collections.ArrayList strList = new System.Collections.ArrayList();
        foreach (object obj in mixedList)
        {
            if (obj.GetType().Equals(typeof(int)))
            {
                intList.Add(obj);
            }
            else if (obj.GetType().Equals(typeof(string)))
            {
                strList.Add(obj);
            }
            else
            {
                // error.
            }
        }
