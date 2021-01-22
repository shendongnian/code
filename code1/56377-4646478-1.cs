      public void MethodDictionary()
      {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        dictionary.Add("cat", 2);
        dictionary.Add("dog", 1);
        dictionary.Add("llama", 0);
        dictionary.Add("iguana", -1);
        //dictionary.Add(1, -2); // Compilation Error
        foreach (KeyValuePair<string, int> pair in dictionary)
        {
            lblDisplay.Text = pair.Value + " " + lblDisplay.Text;
        }
      }
