    using System.Reflection;
    public class TableBase : System.Data.Objects.DataClasses.EntityObject
    {
        protected override void OnPropertyChanged(string property)
        {
            base.OnPropertyChanged(property);
    
            if (property != "DateUpdated")
            {
                PropertyInfo prop = this.GetType().GetProperty("DateUpdated");
                if (prop != null && prop.PropertyType.IsAssignableFrom(typeof(DateTime)))
                {
                    prop.SetValue(this, DateTime.Now, null);
                }
            }
        }
    }
