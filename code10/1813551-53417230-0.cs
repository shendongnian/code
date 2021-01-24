    public class MyNewClass : BaseClass
    {
        public MyNewClass(BaseClass seizeProperties)
        {
            PropertyInfo[] baseProperties = typeof(BaseClass).GetProperties();
            foreach (PropertyInfo property in baseProperties)
            {
                property.SetValue(this, property.GetValue(seizeProperties));
            }
        }
        public int? ExtraProperty { get; set; }
    }
