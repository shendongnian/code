    private void SaveFile(string fileLocation)
      {
      StreamWriter writeFile = new StreamWriter(fileLocation);
    
      try
        {    
        writeFile.WriteLine(textBox1.Text);
        writeFile.WriteLine(textBox2.Text);
        //etc.
        }
      catch(Exception)
        {
        MessageBox.Show("Save file failed");
        }
      finally
        {
        writeFile.Close();
        }
      }
