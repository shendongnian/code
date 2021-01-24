    public class ServiceItem :INotifyPropertyChanged
    {
     private string uniqueId,operation,operationType,operationStatus,statusMessage;
     private bool statusVisible;
    
     public string UniqueId { get { return uniqueId; } set { uniqueId= value; RaisePropertyChanged(nameof(UniqueId)); } }
     
     public string Operation { get { return operation; } set { operation= value; RaisePropertyChanged(nameof(Operation)); } }
    
     public string OperationType { get { return operationType; } set { operationType= value; RaisePropertyChanged(nameof(OperationType)); } }
     
     public string OperationStatus { get { return operationStatus; } set { operationStatus= value; RaisePropertyChanged(nameof(OperationStatus)); } }
     
     public string StatusMessage { get { return statusMessage; } set { statusMessage= value; RaisePropertyChanged(nameof(StatusMessage)); } }
     
     public bool CanStatusVisible { get { return statusVisible; } set { statusVisible= value; RaisePropertyChanged(nameof(CanStatusVisible )); } }
    }
