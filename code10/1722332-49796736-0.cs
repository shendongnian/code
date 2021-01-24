    List<String> Arrays = new List<string>();
    
    private void button5_Click(object sender, EventArgs e) // Add a new genre
    {
         NumOfGenres++;
    
         string GenreTitle = My_Dialogs.InputBox("Please name the genre");
    
         textBox1.Text = GenreTitle;
    
         Console.WriteLine("Enter");
         Arrays.Add(GenreTitle);
    }
