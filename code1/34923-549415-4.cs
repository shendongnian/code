    class MyForm
    {
      ListBox listBox = new ListBox();
      MyClass myClass;
      MyForm()
      {
        //pass the Log action to classes which need to use it
        myClass = new MyClass(Log);
        //test it
        myClass.Something();
      }
      ///logs strings by writing them to the ListBox
      void Log(string s)
      {
        if (listBox.Items.Count == 300)
          listBox.Items.RemoveAt(0);
        listBox.Items.Add(s);
      }
    }
