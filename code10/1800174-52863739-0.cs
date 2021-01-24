     string text = "&2&LL&1&likk&3&";
            string[] xx = text.Split('&');
            string text2 = "";
            string[] abc = { "A","B","C","D","E","F","G","H","I","J" };
            for (int i = 0; i < xx.Length; i++)
            {
                text2 += xx[i];
            }
            for (int i = 0; i < abc.Length; i++)
            {
                text2 = text2.Replace(""+i, abc[i]);
            }
            MessageBox.Show(text2);
