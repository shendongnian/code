      static void Main(string[] args) {
        List<double> list = ReadDoubles();
        if (list.Count <= 0)
          Console.WriteLine("Empty list: no average");
        else {
          double sum = 0.0;
       
          foreach (double item in list)
            sum += item;
          double avg = sum / list.Count;
          Console.Write("The average is: " + avg);
        }
      }
