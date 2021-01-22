        public ImageSource GetGlowingImage(string name)
        {
            string fileName = string.Empty;
            switch (name)
            {
                case "Andromeda":
                    {
                        fileName = "HeroGlowIcons/64px-Andromeda.gif";
                        break;
                    }
            }
            BitmapImage glowIcon = new BitmapImage();
            glowIcon.BeginInit();
            glowIcon.UriSource = new Uri("pack://application:,,,/ApplicationName;component/" + fileName);
            glowIcon.EndInit();
            return glowIcon;
        }
