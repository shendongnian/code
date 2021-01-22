            public void DisplayPopup (string Title, string Text, string AssetPicturePath, SpriteBatch batch)
        {
            FillText = new Texture2D(game.GraphicsDevice, 1, 1);
            FillText.SetData(new Color[] { Color.White });
            //Draw rectangle, center screen,
            Rectangle MainBox;
            MainBox.Width = 700;
            MainBox.Height = 400;
            MainBox.X = game.Window.ClientBounds.Width / 2 - MainBox.Width / 2;
            MainBox.Y = game.Window.ClientBounds.Height / 2 - MainBox.Height / 2;
            //Draw Title
            Rectangle TitleBox;
            TitleBox.Width = 650;
            TitleBox.Height = (int)ArialFont.MeasureString(Title).Y;
            Padding = MainBox.Width / 2 - TitleBox.Width / 2;
            TitleBox.X = (int)Padding + MainBox.X;
            TitleBox.Y = (int)Padding + MainBox.Y;
            //Draw Line Between Title and TextBox
            Rectangle TextSeperator;
            TextSeperator.Width = MainBox.Width - (int)Padding * 2;
            TextSeperator.Height = 1;
            TextSeperator.X = MainBox.X + (int)Padding;
            TextSeperator.Y = TitleBox.Y + (int)(Padding * 1.2);
            //Draw PictureBox
            Rectangle PictureBox;
            if (AssetPicturePath != string.Empty)
                PictureBox.Width = 200;
            else
                PictureBox.Width = 0;
            PictureBox.Height = 250;
            PictureBox.X = MainBox.X + (int)Padding;
            PictureBox.Y = MainBox.Y + TitleBox.Height + (int)Padding * 2;
            MainBox.Height = PictureBox.Y - MainBox.Y + PictureBox.Height + (int)Padding;
            //Draw TextBody
            Rectangle TextBody;
            if (AssetPicturePath == string.Empty)
                TextBody.Width = MainBox.Width - ((int)Padding * 2);
            else
                TextBody.Width = MainBox.Width - ((int)Padding * 3) - PictureBox.Width;
            TextBody.Height = MainBox.Height - ((int)Padding * 3) - TitleBox.Height;
            if (AssetPicturePath == string.Empty)
                TextBody.X = PictureBox.X;
            else
                TextBody.X = PictureBox.X + PictureBox.Width + (int)Padding;
            TextBody.Y = TitleBox.Y + TitleBox.Height + (int)Padding;
            //Draw MainBox
            batch.Draw(FillText, MainBox, Color.Wheat);
            //Draw PictureBox
            //batch.Draw(FillText, PictureBox, Color.Green);
            if (AssetPicturePath != string.Empty)
                batch.Draw(game.Content.Load<Texture2D>(AssetPath + AssetPicturePath.TrimStart(new char[] { '/' })), PictureBox, Color.White);
            //Draw TitleBox
            //batch.Draw(FillText, TitleBox, Color.BlueViolet);
            batch.DrawString(ArialFont, Title, new Vector2(TitleBox.X, TitleBox.Y),Color.Blue);
            //Draw Line Between Title And TextBody
            batch.Draw(FillText, TextSeperator, Color.Gray);
            //Draw TextBody
            //batch.Draw(FillText, TextBody, Color.Indigo);
            int LineNumber = 0;
            foreach (string Line in WrapText(Text, TextBody.Width))
            {
                batch.DrawString(ArialFont, Line, new Vector2(TextBody.X, TextBody.Y + (LineNumber * ArialFont.MeasureString(Line).Y)), Color.Black);
                LineNumber++;
            }
        }
        private object[] WrapText(string text, float Length)
        {
            string[] words = text.Split(' ');
            ArrayList Lines = new ArrayList();
            float linewidth = 0f;
            float spaceWidth = ArialFont.MeasureString(" ").X;
            int CurLine = 0;
            Lines.Add(string.Empty);
            foreach (string word in words)
            {
                Vector2 size = ArialFont.MeasureString(word);
                if (linewidth + size.X < Length)
                {
                    Lines[CurLine] += word + " ";
                    linewidth += size.X + spaceWidth;
                }
                else
                {
                    Lines.Add(word + " ");
                    linewidth = size.X + spaceWidth;
                    CurLine++;
                }
            }
            return Lines.ToArray();
        }
