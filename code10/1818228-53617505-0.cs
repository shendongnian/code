    public class GameWindows
    {
        private Image _firstSelected = null;
        private void Image_Click(object sender, EventArgs e)
        {
            var selectedImage = (Image)sender;
            if(_firstSelected == null)
            {
                //First selection
                _firstSelected = selectedImage;
                ApplySeletedEffect(selectedImage);
            }
            else
            {
                //Second selection
                if ((string)selectedImage.Tag == (string)_firstSelected.Tag)
                {
                    selectedImage.Visible = false;
                    _firstSelected.Visible = false;
                }
                RemoveSeletedEffect(_firstSelected);
                _firstSelected = null;
            }
        }
    }
