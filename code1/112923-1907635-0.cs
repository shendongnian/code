    public class MyViewModel : BaseViewModel    
    {    
        public int Result    
        {    
            get { return _result; }    
            set    
            {    
                _result = value;     
    
    			Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new WorkMethod(delegate
    				{
    					this._result = SampleMethodChangingResult();
    				}));
    
                this.RaisePropertyChanged("Result");    
            }    
        }    
    }  
