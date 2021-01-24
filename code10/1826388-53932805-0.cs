    public ICommand OnEdit { get; set; }
    OnEdit= new Command(EditAction); 
    private void EditAction(object obj)
    { 
     Debug.Write("OK"); 
    }
