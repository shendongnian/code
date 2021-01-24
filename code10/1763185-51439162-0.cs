    string[] accountData = { nick, password };
    if(checkbox.Checked)
    {
         System.IO.File.WriteAllLines(@"YourFile.txt", data);
    }
