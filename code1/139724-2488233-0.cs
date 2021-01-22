    public static void blah()
        {
            TextBox[] textarray = new TextBox[100];
            List<TextBox> textBoxList = new List<TextBox>();
            for (int i = 0; i < textarray.Length; i++)
            {
                textarray[i] = new TextBox();
                textarray[i].Height = 30;
                textarray[i].Width = 50;
    
                // events registration
                textarray[i].Click += 
                      new EventHandler(TextBoxFromArray_Click);
                textarray[i].DoubleClick += 
                      new EventHandler(TextBoxFromArray_DoubleClick);
            }
        }
        
        static void TextBoxFromArray_Click(object sender, EventArgs e)
        {
            // implement Event OnClick Here
        }
    
        static void TextBoxFromArray_DoubleClick(object sender, EventArgs e)
        {
            // implement Event OnDoubleClick Here
        }
