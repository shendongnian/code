      public static int TheSecondMax()
      {
          List<int> myList = new List<int>() { 10, 20, 8, 20, 9, 5, 20, 10 };
          int max = int.MinValue;
          int secondMax = int.MinValue;
          foreach (var item in myList)
          {
              if (item > max)
              {
                  max = item;
              }
              if (item > secondMax && item < max)
              {
                  secondMax = item;
              }
          }
          return secondMax;
      }
