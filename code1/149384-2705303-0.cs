    public IMyViewModel CreateMyViewModel( IModel model){
        if (model is Model<A>)
            return new ViewModel(model as Model<A>);
        if (model is Model<B>)
            return new ViewModel(model as Model<B>);
        ...etc..
    }
    
