    private bool _canShowPopup = true;
    
    MessagingCenter.Subscribe<UploadImagePopupPage>(this, "complete", (sender) =>
    {
    
       ShowImagePopUp();
    });
    
    public async void ShowImagePopUp()
        {
            try
            {
                if(_canShowPopup)
                {
                    _canShowPopup = false;
                //Removing current popup
                await PopupNavigation.Instance.PopAsync();
    
                 //Checking one condition
                if (Utility.picturecount < _images.Count)
                {
                   // Following popup code invoking 2 times
                    await PopupNavigation.Instance.PushAsync(new UploadImagePopupPage(_images[Utility.picturecount]), true);
                }
                else
                {
                    _images.Clear();
                    await Navigation.PopModalAsync();
                }
                Utility.loadPhotoAlbum = true;
                _canShowPopup = true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception:>>"+e);
                _canShowPopup = true;
            }
        }
