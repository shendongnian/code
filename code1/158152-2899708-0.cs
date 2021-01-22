    if (!string.IsNullOrEmpty(myObject.Description))
    {
        string original = myObject.Description;
        string[] words = original.Split(' ');
        if (words.Length < 70)
        {
            uxDescriptionDisplay.Text = 
                 string.Format("<p>{0}</p>", original);
        }
        else
        {                        
            string shortDesc = string.Empty;
            for(int i = 0; i < 70; i++) shortDesc += words[i] + " ";
            uxDescriptionDisplay.Text = 
                 string.Format("<p>{0}</p>", shortDesc.Trim());
         }
     }
