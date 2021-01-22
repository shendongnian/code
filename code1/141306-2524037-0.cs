    C#
    static void Main(string[] args)
        {
    
          //Input : {5, 13, 6, 5, 13, 7, 8, 6, 5}
    
          //Output : {5, 5, 5, 13, 13, 6, 6, 7, 8}
    
          //The question is to arrange the numbers in the array in decreasing order of their frequency, preserving the order of their occurrence.
    
          //If there is a tie, like in this example between 13 and 6, then the number occurring first in the input array would come first in the output array.
    
          List<int> input = new List<int>();
          input.Add(5);
          input.Add(13);
          input.Add(6);
          input.Add(5);
          input.Add(13);
          input.Add(7);
          input.Add(8);
          input.Add(6);
          input.Add(5);      
    
          Dictionary<int, FrequencyAndValue> dictionary = new Dictionary<int, FrequencyAndValue>();
    
          foreach (int number in input)
          {
            if (!dictionary.ContainsKey(number))
            {
              dictionary.Add(number, new FrequencyAndValue(1, number) );
            }
            else
            {
              dictionary[number].Frequency++;
            }
          }
    
          var result = dictionary.OrderByDescending(outer => outer.Value.Frequency);
          
          // BEGIN Priting results with the help of stackoverflow answers 
          Console.Write("With Items: ");    
          foreach (var item in result)
          {
            for (int i = 0; i < item.Value.Frequency; i++)
            {
              Console.Write(item.Value.Value + " ");
            }
            //Console.WriteLine(item.Value.Frequency + " " + item.Value.Value);
          }
          Console.WriteLine();
          Console.Write("With IOrderedEnumerable: ");    
          IOrderedEnumerable<KeyValuePair<int, FrequencyAndValue>> myres = result;
          foreach (KeyValuePair<int, FrequencyAndValue> fv in myres)
          {
            for(int i = 0; i < fv.Value.Frequency; i++ )
            {
              Console.Write(fv.Value.Value + " ");
            }
          }
          Console.WriteLine();
          // END Priting results with the help of stackoverflow answers 
          Console.ReadLine();
        }
        class FrequencyAndValue
        {
          public int Frequency{ get; set;}
          public int Value{ get; set;}
          public FrequencyAndValue(int myFreq, int myValue)
          {
            Value = myValue;
            Frequency = myFreq;
          }
        }
    }
