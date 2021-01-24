    private Person_Model selectedPerson;
    
    public Person_Model SelectedPerson { 
      get
      {
        return this.selectedPerson;
      }
      set
      {
        if (value != this.selectedPerson)
        {
          this.selectedPerson = value;
          NotifyPropertyChanged();
        }
      }
    }
