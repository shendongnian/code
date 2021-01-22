    class Program {
    		public static void Start( string[] args ) {
    			var john = new Customer {
    				CustomerID = Guid.NewGuid(),
    				CustomerName = "John",
    				CustomerCode = "J-O"
    			};
    
    			var tblJohn = john.ToDataTable();
    			var clonedJohn = tblJohn.Rows[0].ToDataObject<Customer>();
    		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class DataColumnAttribute : Attribute { }
	public class Customer {
		[DataColumn]
		public Guid CustomerID { get; set; }
		[DataColumn]
		public string CustomerName { get; set; }
		[DataColumn]
		public string CustomerCode { get; set; }
	}
	public static class DataObjectExtensions {
		public static T ToDataObject<T>( this DataRow dataRow ) where T : new() {
			var dataObject = Activator.CreateInstance<T>();
			var tpDataObject = dataObject.GetType();
			foreach ( var property in tpDataObject.GetProperties() ) {
				var attributes = property.GetCustomAttributes( typeof( DataColumnAttribute ), true );
				if ( null != attributes && attributes.Length > 0 ) {
					if ( property.CanWrite ) {
						DataColumn clm = dataRow.Table.Columns[property.Name];
						if ( null != clm ) {
							object value = dataRow[clm];
							property.SetValue( dataObject, value, null );
						}
					}
				}
			}
			return dataObject;
		}
		public static DataTable ToDataTable( this object dataObject ) {
			var tpDataObject = dataObject.GetType();
			DataTable tbl = new DataTable();
			DataRow dataRow = tbl.NewRow();
			foreach ( var property in tpDataObject.GetProperties() ) {
				var attributes = property.GetCustomAttributes( typeof( DataColumnAttribute ), true );
				if ( null != attributes && attributes.Length> 0 ) {
					if ( property.CanRead ) {
						object value = property.GetValue( dataObject, null );
						DataColumn clm = tbl.Columns.Add( property.Name, property.PropertyType );
						dataRow[clm] = value;
					}
				}
			}
			tbl.Rows.Add( dataRow );
			tbl.AcceptChanges();
			return tbl;
		}
	}
