            Open("D:/Doc1.doc");
            if (oDoc.Bookmarks.Exists("bkmFirstName"))
            {
                object oBookMark = "bkmFirstName";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = textBox1.Text;
            }
            if (oDoc.Bookmarks.Exists("bkmLastName"))
            {
                object oBookMark = "bkmLastName";
                oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = textBox2.Text;
            }
            SaveAs("D:/Test/Doc2.doc"); Quit();
            MessageBox.Show("The file is successfully saved!");
