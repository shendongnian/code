    //Get the FileInfo from the ListBox Selected Item
    FileInfo SelectedFileInfo = (FileInfo) listBox.SelectedItem;   
    //Open a stream to read the file 
    StreamReader FileRead = new StreamReader(SelectedFileInfo.FullName);
    string CurrentLine = "";
    int LineCount = 0;
    //While it is not the end of the file
    while(FileRead.Peek() != -1)
      {
      //Read a line
      CurrentLine = FileRead.ReadLine();
      //Keep track of the line count
      LineCount++;
   
      //if the line count fits your condition of 5n + 2
      if(LineCount % 5 == 2)
        {
        //add it to the second list box
        listBox2.Items.Add(CurrentLine);
        }
      }
    //Close the stream so the file becomes free!
    FileRead.Close();
