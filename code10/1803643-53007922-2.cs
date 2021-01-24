    public class BaseModeNoticable:BaseModel
    {
        public IBaseNotice Notice { get ; set; } 
        public BaseModeNoticable(IBaseNotice baseNotice) 
        {
            Notice = baseNotice;
        }
    }
