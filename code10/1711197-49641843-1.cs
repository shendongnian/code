    public Command PopupCommand
        {
            get
            {
                return new Command(async () => {
                    Content1Page view = new Content1Page();
                    await PopupNavigation.Instance.PushAsync(new CustomPopup(view));
                });
            }
        }
