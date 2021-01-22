    Xaml: <TextBlock x:Name="txt_Txt"/>
    foreach (var itm5 in "! Hello World !; %Hello World%".Split(';'))
    {
           if (txt_Txt.Inlines.Count() > 0)
               txt_Txt.Inlines.Add(new Run("\r\n"));
           foreach (var letter in itm5)
           {
                if (char.IsSymbol(letter))
                   txt_Txt.Inlines.Add(new Run(letter.ToString()) { Foreground = Brushes.Red });
                else
                    txt_Txt.Inlines.Add(new Run(letter.ToString()) { Foreground = Brushes.Black });
            }
    }
