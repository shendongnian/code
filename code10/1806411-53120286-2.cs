    public class PrimaryTableModel {
           public int PrimaryTableID {get;set;}
           //if there's a one to one relationship between primary table and county
           public CountyInfo County {get;set;}
           //or if there's a many to one relationship 
           public CountyInfoList CountiesList {get;set;}
     }
