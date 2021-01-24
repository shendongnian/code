    private void Search_Click(object sender, EventArgs e)
    {
        Books tempbook = null;
        if (String.IsNullOrWhiteSpace(ISBNBox.Text) == false && String.IsNullOrEmpty(ISBNBox.Text) == false)
        {
            String isbn = ISBNBox.Text;
            if(Library.ContainsKey(isbn)){
                tempbook = Library[isbn];
            }
        }
        else if (String.IsNullOrWhiteSpace(TitleBox.Text) == false && String.IsNullOrEmpty(TitleBox.Text) == false)
        {
            String title = TitleBox.Text;
            foreach (KeyValuePair<string, Books> element in Library)
            {
                if (element.Value.Title == title)
                {
                    tempbook = element.Value;
                    break;
                }
            }
        }    
        if(tempbook != null)
            Titlebox2.Text = tempbook.Title;
            ISBN2.Text = tempbook.ISBN;
            if (tempbook.Onloan == true)
            {
                LoanBox.Text = tempbook.Title + " Is on loan";
            }
            else
            {
                LoanBox.Text = tempbook.Title + " Is not on loan";
            }
        } else {
        //Handle case where book is not found
        }
    }
