    for (int i=0; i<3; i++)
    {
        string txt = $"B{i}";
        bar[i].Click += delegate
        {                    
            richTextBox1.Text = txt;
        };
    }
  
