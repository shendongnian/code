    public class InProgressDeliveriesViewModel: BaseDeliveryViewModel{
    
         public InProgressDeliveriesViewModel():base(filterParams){}
    }
    
    public class FinishedDeliveriesViewModel: BaseDeliveryViewModel{
    
         public FinishedDeliveriesViewModel():base(filterParams){}
    }
    
    public class BaseDeliveryViewModel{
    
       private FilterObjectOfSomeSort _filterParams;
    
       public BaseDeliveryViewModel(filterParams whatever){
          //use these params to filter for api calls, data.  If you are calling the same 
          //endpoint pass up the filter
          _filterParams = whatever;
        }
    
       public ObservableCollection<MyDeliveryModel> Deliveries {get;set;}
    
       public async Task LoadDeliveries(){
           //use the filter params to load correct data
           var deliveries = await apiClient.GetDeliveries(filterParams); //however you 
           //are gathering data
       }
    
    .... All of your other commands
    
    }
