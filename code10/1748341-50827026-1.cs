    class YourForm : Form
    {
        List<Int_String> myList = new List<Int_String>(); //Create list of our custom class
        public YourForm()
        {
            PopulateMyList();
        }
        private void PopulateMyList()
        {
            //Here read from database or get data somehow and populate our list like this
            //I will populate it manually but you do it in foreach loop
            myList.Add(new Int_String { _int = 0, _string = "First Item" });
            myList.Add(new Int_String { _int = 1, _string = "Second Item" });
            myList.Add(new Int_String { _int = 2, _string = "Third Item" });
        }
    }
