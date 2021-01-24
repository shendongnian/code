    public int buttonClickCounter = 0;
    private void button1_Click_1(object sender, EventArgs e)
    {   
       List<string> fileContentList = new List<string>();
       string fileInfo = "";
       StreamReader reader = new StreamReader("C://Users//Rehan Shah//Desktop//Text1.txt");
       while ((fileInfo = reader.ReadLine()) != null)
       {
          fileContentList.Add(fileInfo);
       }
    
       try
       {
          listBox1.Items.Add(fileContentList[buttonClickCounter]);
          buttonClickCounter++;
       }
       catch (Exception ex)
       {
          MessageBox.Show("All Contents is added to the file.");
       }
    }
