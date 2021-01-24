    string[] lines = File.ReadAllLines("settings.txt");
    foreach(string setting in lines)
    {
         string[] s = setting.Split('=');
         switch(s[0].Trim())
         {
              case "SomeComboBoxValue":
                  ComboBox1.SelectedIndex = int.Parse(s[1].Trim()); break;
              case "SomeButtonValue":
                  Button1.Text = s[1].Trim(); break;
             //goes on like this
         }
    }
