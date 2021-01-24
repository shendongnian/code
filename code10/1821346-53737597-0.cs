    public MainWindow()
        {
            InitializeComponent();
            letters = new List<string> { "a", "b", "c", "d", "e", "f" };
            myList1 = new List<string> { "f3", "g4", "h5" };
            myList2 = new List<string> { "z5", "w7", "q9" };
            myList3 = new List<string> { "k5", "n7" };
            FillLists(letters, new List<List<string>> { myList1, myList2, myList3 });
        }
        private void FillLists(List<string> listToFillWith, List<List<string>> allLists)
        {
            char lastItemInList = listToFillWith.Last()[0]; //We get the last item inside the listToFillWith list and with the [0] we convert this string to a char
            foreach (List<string> list in allLists) //We loop through each list inside allLists
            {
                while(list.Count != 5) //While either list 1, 2 or 3 does not have 5 items
                {
                    if (listToFillWith.Count > 0) //Make sure our listToFillWith still has items to fill our list
                    {
                        list.Add(listToFillWith[0]); //Add the first item from listToFillWith to our list
                        listToFillWith.Remove(listToFillWith[0]); //Remove the first item from listToFillWith so we don't add it again
                    }
                    else //If listToFillWith is empty
                    {
                        
                        char nextLetter;
                        //Here we check if the last item in the listToFillWith is a Z or z
                        if (lastItemInList == 'z')
                        {
                            nextLetter = 'a';
                        }
                        else if (lastItemInList == 'Z')
                        {
                            nextLetter = 'A';
                        }
                        else //If the last item in the listToFillWith is not a Z or z we get the last letter and go to the next letter in the alphabet
                        {
                            nextLetter = (char)(((int)lastItemInList) + 1);
                        }
                        list.Add(nextLetter.ToString()); //Add the next letter in the alphabet to the list
                    }
                }
            }
        }
