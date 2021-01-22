    public static DataRowExtensionsMethods {
        public static void ForNotNull<T>( this DataRow row, string columnName, Action<T> action ) {
            object rowValue = row[columnName];
            if ( rowValue is T ) {
                action( (T)rowValue );
            }
        }
    }
    // somewhere else
    Row.ForNotNull<CustomData>( "column1", cutomData => this.textBox1.Text = customData.Username );
