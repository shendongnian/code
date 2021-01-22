    public enum TransactionTypeCode {
    
      Shipment("S"),Receipt ("R");
    
      private final String val;
    
      TransactionTypeCode(String val){
        this.val = val;
      }
    
      public String getTypeCode(){
        return val;
      }
    }
    
    System.out.println(TransactionTypeCode.Shipment.getTypeCode());
