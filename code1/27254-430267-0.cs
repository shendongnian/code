    public class TimeFrame: IComparable
    {
       private int days;
       public int Days
       {
            set 
            {
                 days = value;
            }
       }
       
       public int CompareTo(object other)
       {
            //see this for implementation -- http://msdn.microsoft.com/en-us/library/system.icomparable.aspx#Mtps_DropDownFilterText
       }
       public string Description
       {
           get code to return the description string , ie "1-3 months"
       }
    }
