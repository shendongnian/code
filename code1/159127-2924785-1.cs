       namespace SomeCompany.UI
        {
        public class ManualPresenter : INotifyPropertyChanged, IDataErrorInfo
        	{
        		#region Fields
                        //fields
                        #endregion Fields
        
                        public string SomeFormField
                        { get{ return _someFormField;}
                          set{
                                if(_someFormField != value)
                                  {
                                     _someFormField = value;
                                      //Update Model if Needed
                                      _model.SomeFormField = _someFormField;
                                     NotifyCHanged("SomeFormField");
                                   }
                              }
                         }
                      
