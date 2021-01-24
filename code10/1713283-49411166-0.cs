        private static bool CheckImage(string filename)
        {
            try
            {
                using (var image = Image.FromFile(filename))
                {
                    if(image.Height<2 && image.Width<2)
                        return false
                }
                return true;
            }
            catch (Exception ex)
            {
                // probably should log more information here
                return false;
            }
        }
