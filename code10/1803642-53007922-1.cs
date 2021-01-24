    public class BaseModel
    {
        public int Id { get; set; }
        public int CreatedDate { get; set; }
        public override string ToString();
    }
 
    public interface IBaseNotice
    {
       // Base Notices Contracts should be placed here
    }
    Public class BaseNotice: IBaseNotice
    {
        // Common info related to notice which is use to send notice to employees in different scenarios
    }
    public class ModelX:BaseModel
    {
        public IBaseNotice Notice { get ; set; } 
        public ModelX(IBaseNotice baseNotice) 
        {
            Notice = baseNotice;
        }
    }
