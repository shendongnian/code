    private $Type$ _$PropertyName$;
    public $Type$ $PropertyName$
    {
        get
        {
            return _$PropertyName$;
        }
        set
        {
            if(value != _$PropertyName$)
            {
                _$PropertyName$ = value;
                OnPropertyChanged(o => o.$PropertyName$);				
            }
        }
    }
