    public class MyCustomDataGridView : DataGridView
        {
    
            public MyCustomDataGridView()
            {
                this.AutoGenerateColumns = false;
            }
    
            public void Load<T>(ICollection<T> collection)
            {
    
                foreach(object myAttribute in typeof(T).GetCustomAttributes(typeof(MyPropertyAttribute).GetType(), true))
                {
                    if (((MyPropertyAttribute)myAttribute).Visibility == MyPropertyAttribute.VisibilityOptions.visible)
                    {
                        //...
                    }
                }
    
            }
    
        }
