    private void MoveSeiteUp()
    {
     const int smallestReihenfolge = 1;
     if (this.SelectedBild.Reihenfolge > smallestReihenfolge) {
            var bildToSwapReihenfolgeWith = this.Bilder.Single(b => b.Reihenfolge == this.SelectedBild.Reihenfolge - 1);
            this.SelectedBild.Reihenfolge--;
            bildToSwapReihenfolgeWith.Reihenfolge++;
            this.Bilder = new ObservableCollection<BildNotifiableModel> (this.Bilder);
            RaisePropertyChanged(nameof(this.Bilder));
        }
    }
    private void MoveSeiteDown()
    {
        if (this.SelectedBild.Reihenfolge < MaxAllowedImages) {
            var bildToSwapReihenfolgeWith = this.Bilder.Single(b => b.Reihenfolge == this.SelectedBild.Reihenfolge + 1);
            this.SelectedBild.Reihenfolge++;
            bildToSwapReihenfolgeWith.Reihenfolge--;
            this.Bilder = new ObservableCollection<BildNotifiableModel> (this.Bilder);
            RaisePropertyChanged(nameof(this.Bilder));
        }
    }
