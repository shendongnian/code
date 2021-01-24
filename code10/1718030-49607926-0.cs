    Navigation.PushAsync(new PageA());
    
    // In Page A
    Navigation.PushAsync(new PageB());
    Navigation.RemovePage(this);
    
    // In Page B
    Navigation.PushAsync(new PageC());
    // In Page C
    Navigation.PushAsync(new PageD());
    Navigation.RemovePage(this);
