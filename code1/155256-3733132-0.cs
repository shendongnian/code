      string s = Interaction.InputBox("enter search text", "Notepad-search", "", 100, 100);
        //The above syntax is from vb.net so add reference as microsoft.VisualBasic from   references. The above code creates an alertbox. Then type the text which you want search and click on ok.
               int f = richTextBox1.Find(s);
               if (f >= 0)
               {
                   MessageBox.Show("search Text is found");
               }
               else
               {
                   MessageBox.Show("search Text is not found");
               }
