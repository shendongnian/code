    private void OnLinkedScrollView_Scrolled()
    {
        Element.IsVisible = false;
        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        {
            if(Element != null){
                Element.IsVisible = true;
            }
            return false;
        });
    }
