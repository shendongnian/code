    switch(btnMyButton.Tag.ToString()){
       case "text1":
         text1.Text = (int.Parse(text1.Text) + 1).ToString();
         btnMyButton.Tag = "text2";
       break;
       case "text2":
         text2.Text = (int.Parse(text2.Text) + 1).ToString();
         btnMyButton.Tag = "text3";
       break;
       case "text3":
         text3.Text = (int.Parse(text3.Text) + 1).ToString();
         btnMyButton.Tag = "text4";
       break;
       case "text4":
         text4.Text = (int.Parse(text4.Text) + 1).ToString();
         btnMyButton.Tag = "text5";
       break;
       case "text5":
         text5.Text = (int.Parse(text5.Text) + 1).ToString();
         btnMyButton.Tag = "text1";
       break;
    }
