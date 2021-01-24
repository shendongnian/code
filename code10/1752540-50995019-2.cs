    public interface IUC{
        Button BtnPrev { get; set;}
        Button BtnFirst{ get; set;}
        Button BtnNext{ get; set;}
        Button BtnLast{ get; set;}
        DataGrid DatagridObject{ get; set;}
    	//... all you need property info
    }
    
    public class PartsUC : IUC{
    	Button BtnPrev { get; set;}
        Button BtnFirst{ get; set;}
        Button BtnNext{ get; set;}
        Button BtnLast{ get; set;}
        DataGrid DatagridObject{ get; set;}
    	//... all you need property info
    }
    public class EqupmentUC : IUC{
    	Button BtnPrev { get; set;}
        Button BtnFirst{ get; set;}
        Button BtnNext{ get; set;}
        Button BtnLast{ get; set;}
        DataGrid DatagridObject{ get; set;}
    	//... all you need property info
    }
    public class UsersUC : IUC{
    	Button BtnPrev { get; set;}
        Button BtnFirst{ get; set;}
        Button BtnNext{ get; set;}
        Button BtnLast{ get; set;}
        DataGrid DatagridObject{ get; set;}
    	//... all you need property info
    }
    class Pagenation<T> where T : IUC
    {
    
        public Pagenation(T ClassObj)
        {
    
            this.NumberOfRecords = ClassObj.NumberOfRecords;
            this.numberOfRecPerPage = ClassObj.numberOfRecPerPage;
            //... set your property from PartsUC class
        }
    }
